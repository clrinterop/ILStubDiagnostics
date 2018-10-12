///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

/* This file is best viewed using outline mode (Ctrl-M Ctrl-O) */

// This program uses code hyperlinks available as part of the HyperAddin Visual Studio plug-in.
// It is available from http://www.codeplex.com/hyperAddin 
/* */
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using FastSerialization;

namespace System.Diagnostics.Eventing
{
    public sealed class WPFTraceEventParser : TraceEventParser
    {
        public static string ProviderName = "Windows-Presentation-Framework";
        public static Guid ProviderGuid = new Guid(unchecked((int)0xaa087e0e), unchecked((short)0xb35), unchecked((short)0x4e28), 0x8f, 0x3a, 0x44, 0xc, 0x3f, 0x51, 0xee, 0xf1);
        public WPFTraceEventParser(TraceEventSource source) : base(source) { }

        public event Action<EmptyTraceData> FirstRaster
        {
            add
            {
                                        // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "FirstRaster", FirstRasterGuid, 0, "", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> ApplicationStartup
        {
            add
            {
                                        // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "ApplicationStartup", ApplicationStartupGuid, 0, "", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> ControlStartup
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "ControlStartup", ControlStartupGuid, 0, "", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> MediaRenderStart
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "MediaRender", MediaRenderGuid, 1, "Start", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> MediaRenderStop
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "MediaRender", MediaRenderGuid, 2, "Stop", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> ParseStart
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "Parse", ParseGuid, 1, "Start", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> ParseStop
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "Parse", ParseGuid, 2, "Stop", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> RasterStart
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "Raster", RasterGuid, 1, "Start", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> RasterStop
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "Raster", RasterGuid, 2, "Stop", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> PutSourceStart
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "PutSource", PutSourceGuid, 1, "Start", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> PutSourceStop
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "PutSource", PutSourceGuid, 2, "Stop", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> CLRStartupStart
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "CLRStartup", CLRStartupGuid, 1, "Start", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> CLRStartupStop
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "CLRStartup", CLRStartupGuid, 2, "Stop", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> CoreDrawStart
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "CoreDraw", CoreDrawGuid, 1, "Start", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> CoreDrawStop
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "CoreDraw", CoreDrawGuid, 2, "Stop", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> DownloadRequestStart
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "DownloadRequest", DownloadRequestGuid, 1, "Start", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> DownloadRequestStop
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "DownloadRequest", DownloadRequestGuid, 2, "Stop", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> PutRootVisualStart
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "PutRootVisual", PutRootVisualGuid, 1, "Start", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }
        public event Action<EmptyTraceData> PutRootVisualStop
        {
            add
            {
                // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
                source.RegisterEventTemplate(new EmptyTraceData(value, 0xFFFF, 0, "PutRootVisual", PutRootVisualGuid, 2, "Stop", ProviderGuid, ProviderName));
            }
            remove
            {
                throw new Exception("Not supported");
            }
        }

        #region private
        private static Guid ApplicationStartupGuid = new Guid(unchecked((int)0x3b99be34), unchecked((short)0xa702), unchecked((short)0x477a), 0xbf, 0xff, 0x3b, 0xef, 0xde, 0xfd, 0x5c, 0xe);
        private static Guid FirstRasterGuid = new Guid(unchecked((int)0x84d6a4e1), unchecked((short)0x252a), unchecked((short)0x4742), 0xb5, 0xa8, 0x8d, 0x45, 0xd2, 0xbd, 0x80, 0x1f);
        private static Guid ControlStartupGuid = new Guid(unchecked((int)0xb72aadc1), unchecked((short)0xa110), unchecked((short)0x4221), 0x8e, 0x3, 0x5, 0x42, 0x9a, 0x5b, 0xfa, 0xf9);

        private static Guid MediaRenderGuid = new Guid(unchecked((int)0x21c1ea55), unchecked((short)0x76a7), unchecked((short)0x4819), 0xb0, 0xfb, 0x7c, 0x6f, 0xb1, 0x62, 0x2b, 0xf4);
        private static Guid ParseGuid = new Guid(unchecked((int)0x9835e264), unchecked((short)0x4b9), unchecked((short)0x4ee1), 0x8f, 0xd, 0x66, 0x6c, 0x1a, 0x86, 0xea, 0x24);
        private static Guid RasterGuid = new Guid(unchecked((int)0xe26e6715), unchecked((short)0x54a), unchecked((short)0x4a6c), 0xaa, 0x60, 0x72, 0x6d, 0xd4, 0x12, 0x15, 0xfa);
        private static Guid PutSourceGuid = new Guid(unchecked((int)0xea919d73), unchecked((short)0x2960), unchecked((short)0x49e4), 0x86, 0x49, 0xf4, 0x41, 0xe0, 0x2f, 0x58, 0xcd);
        private static Guid CLRStartupGuid = new Guid(unchecked((int)0x84d1c136), unchecked((short)0x7de5), unchecked((short)0x46c9), 0xb5, 0xb7, 0x26, 0x43, 0x25, 0xc4, 0xa0, 0x1c);
        private static Guid CoreDrawGuid = new Guid(unchecked((int)0xb9460fc7), unchecked((short)0xa0c6), unchecked((short)0x4ca0), 0x8e, 0xd7, 0xbd, 0xdd, 0xd7, 0xef, 0x89, 0x21);
        private static Guid DownloadRequestGuid = new Guid(unchecked((int)0x47ebc335), unchecked((short)0xe0b7), unchecked((short)0x490f), 0x86, 0x45, 0x62, 0xc1, 0xa3, 0x26, 0x1f, 0x73);
        private static Guid PutRootVisualGuid = new Guid(unchecked((int)0xa72c6400), unchecked((short)0x7ef2), unchecked((short)0x4355), 0xb2, 0x31, 0xe3, 0x8f, 0xe4, 0xd6, 0x3a, 0x84);

        #endregion
    }
}
