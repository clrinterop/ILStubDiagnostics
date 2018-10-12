///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Collections;
using System.Text.RegularExpressions;

namespace ILStubDiagnostic
{
    /// <summary>
    /// StubHelpersAPIDictionary is a singleton dictionary, which stores API names as keys, and API
    /// descriptions as values.
    /// Here API refers to System.StubHelpers methods, which are internal methods.
    /// </summary>
    class StubHelpersAPIDictionary
    {
        private Dictionary<string, string> m_dictionary;

        private static string DefaultAPIDescription = Resource.ResourceManager.GetString("Msg_DefaultAPIDescription");

        /// <summary>
        /// Read resource Msg_DefaultAPIDescription, and store the all APIs in the dictionary.
        /// </summary>
        private StubHelpersAPIDictionary()
        {
            m_dictionary = new Dictionary<string, string>();

            string resNameBase = "API_{0:D3}";
            string resName;
            int index = 0;
            string resourceValue = "";
            while (resourceValue != null)
            {
                resName = string.Format(resNameBase, index);
                resourceValue = ResourceStubHelpersAPIManager.GetStringIfExists(resName);
                if (resourceValue != null)
                {
                    int indexOfEqual = resourceValue.IndexOf('=');
                    string key = resourceValue.Substring(0, indexOfEqual);
                    string value = resourceValue.Substring(indexOfEqual + 1);
                    if (string.IsNullOrEmpty(value))
                    {
                        value = DefaultAPIDescription;
                    }
                    m_dictionary.Add(key, value);
                }
                index++;
            }
        }

        private static StubHelpersAPIDictionary s_instance = new StubHelpersAPIDictionary();

        public static StubHelpersAPIDictionary GetInstance()
        {
            return s_instance;
        }

        /// <summary>
        /// Get all API names.
        /// </summary>
        public List<string> GetKeys()
        {
            return m_dictionary.Keys.ToList();
        }

        /// <summary>
        /// Get all API names, which contain the 'name' as substring.
        /// </summary>
        public List<string> GetKeysContaining(string name)
        {
            if (string.IsNullOrEmpty(name))
                return GetKeys();

            List<string> list = new List<string>();
            foreach (string key in m_dictionary.Keys)
            {
                if (key.ToLower().Contains(name.ToLower()))
                {
                    list.Add(key);
                }
            }
            return list;
        }

        /// <summary>
        /// Get the description of the API in the dictionary.
        /// </summary>
        internal bool TryGetValue(string APIName, out string description)
        {
            return m_dictionary.TryGetValue(APIName, out description);
        }
    }
}
