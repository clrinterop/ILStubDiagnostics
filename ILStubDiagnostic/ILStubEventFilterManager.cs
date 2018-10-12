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
    /// The mananger of the all IILStubEventFilterDefs.
    /// All IILStubEventFilterDefs are registered in this manager. Use the filter name as the key to get the
    /// corresponding IILStubEventFilterDef.
    /// </summary>
    class ILStubEventFilterManager
    {
        private static ILStubEventFilterManager s_manager = new ILStubEventFilterManager();

        private List<IILStubEventFilterDef> m_registeredFilterDefList =
            new List<IILStubEventFilterDef>();

        private ILStubEventFilterManager()
        {
            m_registeredFilterDefList.Add(ProcessIdFilterDef.GetInstance());
            m_registeredFilterDefList.Add(ProcessNameFilterDef.GetInstance());
            m_registeredFilterDefList.Add(MethodNameFilterDef.GetInstance());
        }

        public static ILStubEventFilterManager GetInstance()
        {
            return s_manager;
        }

        public List<IILStubEventFilterDef> FilterDefList
        {
            get
            {
                return m_registeredFilterDefList;
            }
        }

        /// <summary>
        /// Get the IILStubEventFilterDef by filter name.
        /// The filter name of an IILStubEventFilterDef is used as the key of IILStubEventFilterDef.
        /// </summary>
        public IILStubEventFilterDef GetFilterDef(string filterName)
        {
            for (int i = 0; i < m_registeredFilterDefList.Count; i++)
            {
                if (m_registeredFilterDefList[i].FilterName.Equals(filterName))
                    return m_registeredFilterDefList[i];
            }
            return null;
        }
    }
}
