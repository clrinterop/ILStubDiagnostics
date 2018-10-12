///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;

namespace ILStubDiagnostic
{
    class ResourceStubHelpersAPIManager
    {
        // The methods only contained static methods
        // Therefore, adding a private constructor to assure it is not
        // instantiated.
        private ResourceStubHelpersAPIManager()
        {
        }
        // For string resources located in a file:
        private static ResourceManager _resmgr;

        internal static ResourceManager ResourceManager
        {
            get
            {
                if (_resmgr == null)
                {
                    _resmgr = new ResourceManager("ILStubDiagnostic.ResourceStubHelpersAPI",
                        Assembly.GetExecutingAssembly());
                }
                return _resmgr;
            }
        }

        internal static String GetStringIfExists(String key)
        {
            return ResourceManager.GetString(key, null);
        }
    }
}
