///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILStubDiagnostic
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class BadFilterDataException : Exception {

        private string m_filterName;
        public string FilterName
        {
            get
            {
                return m_filterName;
            }
        }

        public BadFilterDataException(string filterName)
        {
            m_filterName = filterName;
        }
    }

    public class FilterOperationIsNullException : BadFilterDataException
    {
        public FilterOperationIsNullException(string filterName)
            : base(filterName)
        {
        }
    }

    public class FilterValueNotIntegerException : BadFilterDataException
    {
        private string m_value;
        public string Value
        {
            get
            {
                return m_value;
            }
        }

        public FilterValueNotIntegerException(string filterName, string value)
            : base(filterName)
        {
            m_value = value;
        }
    }

    public class FilterOperationNotSupportException : BadFilterDataException
    {
        private string m_operation;
        public string Operation
        {
            get
            {
                return m_operation;
            }
        }

        public FilterOperationNotSupportException(string filterName, string operation)
            : base(filterName)
        {
            m_operation = operation;
        }
    }

    public class FilterValueIsNullException : BadFilterDataException
    {
        public FilterValueIsNullException(string filterName)
            : base(filterName)
        {
        }
    }
    
}
