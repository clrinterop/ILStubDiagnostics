///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ILStubDiagnostic
{
    /// <summary>
    /// A singleton controller to enable/disable CLR Session and Kernel Session.
    /// This controller is a wrapper of TraceEvent library, and provide a unique access for ILStubEvent
    /// (both ILStub Generated Event and ILStub Cache Hit Event).
    /// Users who are interested in the ILStubEvent can subscribe the ILStubEventAction event.
    /// </summary>
    internal class ILStubDiagnosticSessionController : IDisposable
    {
        /// <summary>
        /// Provider guid for the Common Language Runtime (CLR) (also known as .NET Runtime)
        /// </summary>
        public static Guid ClrProviderGuid { get { return new Guid("e13c0d23-ccbc-4e12-931b-d9cc2eee27e4"); } }

        private Dictionary<int, string> m_pIDToPName = new Dictionary<int,string>();

        private ETWTraceEventSource m_ILStubSource;

        private ETWTraceEventSource m_kernelSource;

        private TraceEventSession m_ILStubSession;

        private TraceEventSession m_kernelSession;

        private Thread m_ILStubProcessTraceThread;

        private Thread m_kernelProcessTraceThread;

        public const string ILStubDiagnosticSessionName = "ILStubDiagnosticSession";

        private static ILStubDiagnosticSessionController s_controller =
            new ILStubDiagnosticSessionController();

        private bool m_isEnabled; // runtime automatically initialized it to false

        private List<ILStubEvent> m_eventList = new List<ILStubEvent>();

        // An index for searching the associated ILStubGeneratedEvent for ILStubCacheHitEvent.
        private Dictionary<int, ILStubGeneratedEvent> m_ilStubGeneratedEventIndex =
            new Dictionary<int, ILStubGeneratedEvent>();

        // Public access to receive ILStubGeneratedEvent and ILStubCacheHitEvent.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        public event Action<ILStubEvent> ILStubEventHandler;

        private ILStubDiagnosticSessionController()
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static ILStubDiagnosticSessionController GetInstance()
        {
            return s_controller;
        }

        public bool IsEnabled
        {
            get
            {
                return m_isEnabled;
            }
        }

        /// <summary>
        /// Enable the Kernel provider and listening to the provider for ProcessStartGroup event,
        /// which is published by the TraceEvent library. ProcessStartGroup events are used to
        /// calculate the ProcessID->ProcessName mapping, which will be used in the UI displaying.
        /// However, this mechanism is not supported on XP/2003, and we cannot receive ProcessStartGroup
        /// events on XP/2003.
        /// </summary>
        public void EnableKernelSession()
        {
            if (m_kernelProcessTraceThread == null)
            {
                m_kernelSession = new TraceEventSession(KernelTraceEventParser.KernelSessionName, null);
                try
                {
                    m_kernelSession.EnableKernelProvider(KernelTraceEventParser.Keywords.Process);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(Resource.ResourceManager.GetString("Err_UnauthorizedAccess"));
                    Environment.Exit(0);
                }
                m_kernelSource = new ETWTraceEventSource(KernelTraceEventParser.KernelSessionName, TraceEventSourceType.Session);
                m_kernelSource.Kernel.ProcessStartGroup += AcceptKernelProcessStartEvent;
                m_kernelProcessTraceThread = new Thread(KernelProcessTraceMethod);
                m_kernelProcessTraceThread.Name = "KernelProcessTrace";
                m_kernelProcessTraceThread.Start();
            }
        }

        /// <summary>
        /// Exit the thread of kernel process trace.
        /// </summary>
        public void ExitKernelTraceProcess()
        {
            if (m_kernelProcessTraceThread != null)
            {
                m_kernelProcessTraceThread.Abort();
            }
        }
        
        /// <summary>
        /// Exit the thread of IL Stub process trace.
        /// </summary>
        public void ExitILStubTraceProcess()
        {
            if (m_ILStubProcessTraceThread != null)
            {
                m_ILStubProcessTraceThread.Abort();
            }
        }

        /// <summary>
        /// Start the CLR provider and start listening to the provider for the ILStub Generated Event
        /// and ILStub Cache Hit Event.
        /// Both two kinds of events will be recorded in ILStubDiagnosticSessionController as an
        /// ILStubGeneratedEvent instance or an ILStubCacheHitEvent instance.
        /// </summary>
        public void EnableILStubSession()
        {
            if (m_isEnabled)
                return;

            TraceEventLevel providerLevel = TraceEventLevel.Informational;

            // create ETW trace session and monitor in real time
            m_ILStubSession = new TraceEventSession(ILStubDiagnosticSessionName, null);
            // start ETW trace session
            try
            {
                m_ILStubSession.EnableProvider(ClrProviderGuid, providerLevel, 0, 0, null);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(Resource.ResourceManager.GetString("Err_UnauthorizedAccess"));
                Environment.Exit(0);
            }

            // Register handlers for ILStubStubGenerated and ILStubStubCacheHit events
            m_ILStubSource = new ETWTraceEventSource(ILStubDiagnosticSessionName, TraceEventSourceType.Session);
            ClrTraceEventParser clrEventParser = new ClrTraceEventParser(m_ILStubSource);
            clrEventParser.ILStubStubGenerated += AcceptILStubEvent;
            clrEventParser.ILStubStubCacheHit += AcceptILStubEvent;

            // Start the clr ETW trace
            m_ILStubProcessTraceThread = new Thread(ILStubProcessTraceMethod);
            m_ILStubProcessTraceThread.Start();
            m_isEnabled = true;
        }

        /// <summary>
        /// Disable the CLR provider and stop listening to the provider for the two kinds of events.
        /// </summary>
        public void DisableILStubSession()
        {
            // stop ETW trace session
            if (!m_isEnabled)
                return;
            // ILStub Session may not be stopped, if it is alreadly started before the application starts.
            m_ILStubSession.Stop();

            // We need to abort the IL Stub Process Trace thread no matter whether ILStub session is stopped.
            ExitILStubTraceProcess();

            m_isEnabled = false;
        }

        /// <summary>
        /// Record the process id -> process name mapping.
        /// </summary>
        private void AcceptKernelProcessStartEvent(TraceEvent data)
        {
            if (data is ProcessTraceData)
            {
                lock (this)
                {
                    m_pIDToPName[data.ProcessID] = data.ProcessName;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "pname"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "pid")]
        public string GetProcessNameById(int pid)
        {
            string pname;
            lock (this)
            {
                if (m_pIDToPName.TryGetValue(pid, out pname) == true)
                {
                    return pname;
                }
            }

            // ETW does not guarantee the order of event. Therefore, process start event may be dispatched after
            // CLR event is dispatched. We wait for 1 second here so that process start event can be processed firstly.
            // Here 1 second is chosen becasue windows flush ETW event every second. We try three times because it also
            // takse time to dispatch the event in consumer side
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);

                lock (this)
                {
                    if (m_pIDToPName.TryGetValue(pid, out pname) == true)
                    {
                        return pname;
                    }
                }
            }

            lock (this)
            {
                // if we fail in getting the process name, we just return the pid
                // we also store the result so that next CLR event with the same pid
                // do not need to wait
                pname = string.Format("({0})", pid);
                m_pIDToPName[pid] = pname;
                return pname;
            }
        }

        /// <summary>
        /// Record both ILStub Generated Event and ILStub CacheHit Event into our own DataStructure
        /// </summary>
        /// <param name="data"> The data structure constructed by TraceEvent library
        /// which presents a ETW event</param>
        private void AcceptILStubEvent(TraceEvent data)
        {
            ILStubEvent ilStubEvent = null;
            ILStubGeneratedTraceData ilStubGeneratedTraceData = data as ILStubGeneratedTraceData;
            if (ilStubGeneratedTraceData != null)
            {
                // record the IL Stub Generated event
                ilStubEvent = new ILStubGeneratedEvent(ilStubGeneratedTraceData);
            }
            else
            {
                ILStubCacheHitTraceData ilStubCacheHitTraceData = data as ILStubCacheHitTraceData;
                if (ilStubCacheHitTraceData != null)
                {
                    ILStubCacheHitTraceData cacheHitTraceData = ilStubCacheHitTraceData;
                    ILStubGeneratedEvent generatedEvent =
                        GetGeneratedEvent(cacheHitTraceData);
                    ilStubEvent = new ILStubCacheHitEvent(
                        cacheHitTraceData, generatedEvent);
                }
            }
            if (ilStubEvent != null)
            {
                lock (m_eventList)
                {
                    m_eventList.Insert(0, ilStubEvent);
                    ILStubGeneratedEvent ilStubGeneratedEvent = ilStubEvent as ILStubGeneratedEvent;
                    if (ilStubGeneratedEvent != null)
                    {
                        int hashCode = GetGeneratedEventHashCode(ilStubEvent.ProcessId,
                            ilStubEvent.StubMethodId);
                        m_ilStubGeneratedEventIndex[hashCode] = ilStubGeneratedEvent;
                    }
                }
                // Fire the ILStub Event.
                ILStubEventHandler(ilStubEvent);
            }
        }

        /// <summary>
        /// Get the corresponding ILStub Generated Event with the same process id and stub method
        /// id with the cache hit event.
        /// </summary>
        private ILStubGeneratedEvent GetGeneratedEvent(ILStubCacheHitTraceData cacheHitTraceData)
        {
            int hashCode = GetGeneratedEventHashCode(cacheHitTraceData.ProcessID,
                cacheHitTraceData.StubMethodID);
            ILStubGeneratedEvent ilStubGeneratedEvent;
            if (m_ilStubGeneratedEventIndex.TryGetValue(hashCode, out ilStubGeneratedEvent))
            {
                return ilStubGeneratedEvent;
            }
            else
            {
                return null;
            }
        }

        private static int GetGeneratedEventHashCode(int processId, long stubMethodID)
        {
            string temp = "" + processId + stubMethodID;
            return temp.GetHashCode();
        }

        /// <summary>
        /// Start the kernel process trace.
        /// </summary>
        private void KernelProcessTraceMethod()
        {
            m_kernelSource.Process();
        }

        /// <summary>
        /// Start the clr process trace.
        /// </summary>
        private void ILStubProcessTraceMethod()
        {
            m_ILStubSource.Process();
        }

        /// <summary>
        /// Get the list of ILStubEvents from the event list, which satisfy the filter.
        /// </summary>
        public List<ILStubEvent> Search(ILStubEventFilterList listFilter)
        {
            List<ILStubEvent> eventList = new List<ILStubEvent>();
            lock (m_eventList)
            {
                for (int i = 0; i < m_eventList.Count; i++)
                {
                    ILStubEvent ilStubEvent = m_eventList[i];
                    if (listFilter.Match(ilStubEvent))
                    {
                        eventList.Add(ilStubEvent);
                    }
                }
            }
            return eventList;
        }

        ~ILStubDiagnosticSessionController()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        void Dispose(bool cleanManagedResource)
        {
            // Dispose the ETW related resources
            if (cleanManagedResource)
            {
                if (m_ILStubSource != null)
                {
                    m_ILStubSource.Dispose();
                    m_ILStubSource = null;
                }
                if (m_ILStubSession != null)
                {
                    m_ILStubSession.Dispose();
                    m_ILStubSession = null;
                }
                if (m_kernelSource != null)
                {
                    m_kernelSource.Dispose();
                    m_kernelSource = null;
                }
                if (m_kernelSession != null)
                {
                    m_kernelSession.Dispose();
                    m_kernelSession = null;
                }
            }
        }
    }

}