///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILStubDiagnostic
{
    /// <summary>
    /// A list of ILStub Event Filter.
    /// </summary>
    internal class ILStubEventFilterList
    {
        private List<IILStubEventFilter> m_filterList = new List<IILStubEventFilter>();

        public void Add(IILStubEventFilter filter)
        {
            m_filterList.Add(filter);
        }

        public void Remove(IILStubEventFilter filter)
        {
            m_filterList.Remove(filter);
        }

        /// <summary>
        /// Only if the ILStubEvent satisfies all filter in the filter list, return true.
        /// </summary>
        public bool Match(ILStubEvent ilStubEvent)
        {
            for (int i = 0; i < m_filterList.Count; i++)
            {
                if (!m_filterList[i].Match(ilStubEvent))
                {
                    return false;
                }
            }
            return true;
        }

        public string Expression
        {
            get
            {
                if (m_filterList.Count == 0)
                {
                    return "[No Filter.]";
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("[\"");
                sb.Append(m_filterList[0].Expression);
                for (int i = 1; i < m_filterList.Count; i++)
                {
                    sb.Append("\"; \"");
                    sb.Append(m_filterList[i].Expression);
                }
                sb.Append("\"]");
                return sb.ToString();
            }
        }
    }
}
