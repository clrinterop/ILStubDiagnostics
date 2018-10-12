using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ILStubDiagnostic
{
    class ProcessIdToNameHelper
    {
        static protected Timer timer;

        static Dictionary<int, string> idToNameDic;

        static ProcessIdToNameHelper()
        {
            timer = null;
            idToNameDic = new Dictionary<int,string>();
        }

        static internal void Start()
        {
            Stop();
            timer = new Timer(CollectProcessInfo, null, 0, 100);
        }

        static internal void Stop()
        {
            if (timer != null)
            {
                timer.Dispose();
                idToNameDic.Clear();
            }

        }

        static internal string GetProcessNameById(int id)
        {
            return idToNameDic[id];
        }

        static public void CollectProcessInfo(object o)
        {
            foreach (Process p in Process.GetProcesses())
            {
                idToNameDic[p.Id] = p.ProcessName;
            }
        }
    }
}
