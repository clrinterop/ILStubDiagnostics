///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Eventing;
using System.Diagnostics;
using System.Threading;

namespace ILStubDiagnostic
{
    /// <summary>
    /// The abstract class of ILStubGeneratedEvent and ILStubCacheHitEvent.
    /// </summary>
    abstract internal class ILStubEvent
    {
        protected ILStubEvent(TraceEvent traceData)
        {
            m_pid = traceData.ProcessID;
            m_processName = GetProcessName(traceData);
            m_tid = traceData.ThreadID;
            m_createTime = traceData.TimeStamp;
        }

        /// <summary>
        /// Id of the process which fired the event
        /// </summary>
        private int m_pid;
        public int ProcessId
        {
            get
            {
                return m_pid;
            }
            protected set
            {
                m_pid = value;
            }
        }

        /// <summary>
        /// Name of the process which fired the event
        /// </summary>
        private string m_processName;
        public string ProcessName
        {
            get
            {
                return m_processName;
            }
            protected set
            {
                m_processName = value;
            }
        }

        /// <summary>
        /// Id of the thread which fired the event
        /// </summary>
        private int m_tid;
        public int ThreadId
        {
            get
            {
                return m_tid;
            }
            protected set
            {
                m_tid = value;
            }
        }

        /// <summary>
        /// Create time of the event
        /// </summary>
        private DateTime m_createTime;
        public DateTime CreateTime
        {
            get
            {
                return m_createTime;
            }
            protected set
            {
                m_createTime = value;
            }
        }
        public string CreateTimeString
        {
            get
            {
                return m_createTime.ToString("M/d/yyyy HH:mm:ss.fff");
            }
        }

        /// <summary>
        /// Id of the clr instance which fired the event
        /// </summary>
        private int m_clrInstanceId;
        public int ClrInstanceId
        {
            get
            {
                return m_clrInstanceId;
            }
            protected set
            {
                m_clrInstanceId = value;
            }
        }

        /// <summary>
        /// Id of the module which fired the event
        /// </summary>
        private long m_moduleId;
        public long ModuleId
        {
            get
            {
                return m_moduleId;
            }
            protected set
            {
                m_moduleId = value;
            }
        }

        /// <summary>
        /// Id of the stub method which fired the event
        /// </summary>
        private long m_stubMethodId;
        public long StubMethodId
        {
            get
            {
                return m_stubMethodId;
            }
            protected set
            {
                m_stubMethodId = value;
            }
        }

        /// <summary>
        /// Flags of the stub
        /// </summary>
        private ILStubGeneratedFlags m_stubFlags;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags")]
        public ILStubGeneratedFlags StubGeneratedFlags
        {
            get
            {
                return m_stubFlags;
            }
            protected set
            {
                m_stubFlags = value;
            }
        }

        /// <summary>
        /// Category is the string representation of StubFlags.
        /// </summary>
        private string m_category;
        public string Category
        {
            get
            {
                if (m_category == null)
                {
                    StringBuilder sb = new StringBuilder();
                    bool isComInterop = ((m_stubFlags & ILStubGeneratedFlags.ComInterop) != 0);
                    bool isReverseInterop = ((m_stubFlags & ILStubGeneratedFlags.ReverseInterop) != 0);
                    if (isReverseInterop)
                    {
                        sb.Append("Reverse ");
                    }
                    if (isComInterop)
                    {
                        sb.Append("Com Interop");
                    }
                    else
                    {
                        sb.Append("P/Invoke");
                    }
                    m_category = sb.ToString();
                }
                return m_category;
            }
        }

        /// <summary>
        /// Token of the managed method related to the interop call
        /// </summary>
        private int m_managedMethodToken;
        public int ManagedMethodToken
        {
            get
            {
                return m_managedMethodToken;
            }
            protected set
            {
                m_managedMethodToken = value;
            }
        }

        /// <summary>
        /// Namespace of the managed method related to the interop call
        /// </summary>
        private string m_managedInteropMethodNamespace;
        public string ManagedInteropMethodNamespace
        {
            get
            {
                return m_managedInteropMethodNamespace;
            }
            protected set
            {
                m_managedInteropMethodNamespace = value;
            }
        }

        /// <summary>
        /// Name of the managed method related to the interop call
        /// </summary>
        private string m_managedInteropMethodName;
        public string ManagedInteropMethodName
        {
            get
            {
                return m_managedInteropMethodName;
            }
            protected set
            {
                m_managedInteropMethodName = value;
            }
        }

        /// <summary>
        /// Combination of ManagedInteropMethodNamespace and ManagedInteropMethodName
        /// </summary>
        private string m_methodName;
        public string MethodName
        {
            get
            {
                if (m_methodName == null)
                {
                    m_methodName = m_managedInteropMethodNamespace + "." +
                        m_managedInteropMethodName;
                }
                return m_methodName;
            }
        }

        /// <summary>
        /// Signature of the managed method related to the interop call
        /// </summary>
        private string m_managedInteropMethodSignature;
        public string ManagedSignature
        {
            get
            {
                return m_managedInteropMethodSignature;
            }
            protected set
            {
                m_managedInteropMethodSignature = value;
            }
        }

        /// <summary>
        /// Signature of the native method related to the interop call
        /// </summary>
        private string m_nativeSignature;
        public string NativeSignature
        {
            get
            {
                return m_nativeSignature;
            }
            protected set
            {
                m_nativeSignature = value;
            }
        }

        /// <summary>
        /// Signature of the stub
        /// </summary>
        private string m_stubMethodSignature;
        public string StubMethodSignature
        {
            get
            {
                return m_stubMethodSignature;
            }
            protected set
            {
                m_stubMethodSignature = value;
            }
        }

        /// <summary>
        /// Contents of IL stub
        /// </summary>
        private string m_stubMethodILCode;
        public string StubMethodILCode
        {
            get
            {
                return m_stubMethodILCode;
            }
            protected set
            {
                m_stubMethodILCode = value;
            }
        }

        /// <summary>
        /// CLR ETW event does not contain the process name. Therefore, we retrieve it by
        /// enabling kernel ETW session and maintain the mapping from process name to process name.
        /// Another option is to invoke the API Process.ProcessName. However, it only works when 
        /// the process is alive. Our case cannot guarentee it so that we cannot opt in it.
        /// </summary>
        /// <param name="traceEvent">event data represent an ETW event</param>
        /// <returns>process name</returns>
        protected static string GetProcessName(TraceEvent traceEvent)
        {
            return ILStubDiagnosticSessionController.GetInstance().GetProcessNameById(traceEvent.ProcessID);
        }
    }

    /// <summary>
    /// A presentation of ILStubGeneratedTraceData.
    /// Extract all information from ILStubGeneratedTraceData in the ctor.
    /// </summary>
    internal class ILStubGeneratedEvent : ILStubEvent
    {
        public ILStubGeneratedEvent(ILStubGeneratedTraceData traceData)
            : base(traceData)
        {
            ClrInstanceId = traceData.ClrInstanceID;
            ManagedInteropMethodName = traceData.ManagedInteropMethodName;
            ManagedInteropMethodNamespace = traceData.ManagedInteropMethodNamespace;
            ManagedSignature = traceData.ManagedInteropMethodSignature;
            ManagedMethodToken = traceData.ManagedInteropMethodToken;
            ModuleId = traceData.ModuleID;
            NativeSignature = traceData.NativeMethodSignature;
            StubGeneratedFlags = traceData.StubFlags;
            StubMethodId = traceData.StubMethodID;
            StubMethodILCode = traceData.StubMethodILCode;
            StubMethodSignature = traceData.StubMethodSignature;
        }
    }

    /// <summary>
    /// A presentation of ILStubCacheHitTraceData.
    /// Extract all information from ILStubCacheHitTraceData in the ctor.
    /// </summary>
    internal class ILStubCacheHitEvent : ILStubEvent
    {
        private ILStubGeneratedEvent m_ILStubGeneratedEvent;
        public ILStubCacheHitEvent(ILStubCacheHitTraceData traceData,
            ILStubGeneratedEvent generatedEvent)
            : base(traceData)
        {
            m_ILStubGeneratedEvent = generatedEvent;
            ClrInstanceId = traceData.ClrInstanceID;
            ManagedInteropMethodName = traceData.ManagedInteropMethodName;
            ManagedInteropMethodNamespace = traceData.ManagedInteropMethodNamespace;
            ManagedSignature = traceData.ManagedInteropMethodSignature;
            ManagedMethodToken = traceData.ManagedInteropMethodToken;
            ModuleId = traceData.ModuleID;
            StubMethodId = traceData.StubMethodID;
            if (m_ILStubGeneratedEvent != null)
            {
                NativeSignature = m_ILStubGeneratedEvent.NativeSignature;
                StubGeneratedFlags = m_ILStubGeneratedEvent.StubGeneratedFlags;
                StubMethodILCode = m_ILStubGeneratedEvent.StubMethodILCode;
                StubMethodSignature = m_ILStubGeneratedEvent.StubMethodSignature;
            }
        }
    }
}
