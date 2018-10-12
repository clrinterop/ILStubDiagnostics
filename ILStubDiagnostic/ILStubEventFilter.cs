///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ILStubDiagnostic
{
    /// <summary>
    /// The interface that all ILStub Event Filters implement. Actually, a filter is a condition.
    /// ILStub Event Filter is used to select and filter a list of ILStub Events. Only when an ILStub Event
    /// satisfies the condition of the filter, can it be included in the filter.
    /// </summary>
    internal interface IILStubEventFilter
    {
        /// <summary>
        /// Tell if the ILStubEvent satisfy this filter's condition.
        /// </summary>
        bool Match(ILStubEvent ilStubEvent);

        /// <summary>
        /// Get the definition of the filter, which is also the creator of the filter.
        /// </summary>
        IILStubEventFilterDef FilterDef
        {
            get;
        }

        /// <summary>
        /// Get the expression of filter's condition.
        /// </summary>
        string Expression
        {
            get;
        }
    }

    /// <summary>
    /// The definition of the IILStubEventFilter.
    /// Every IILStubEventFilter implementation has a corresponding IILStubEventFilterDef implementation.
    /// The IILStubEventFilterDef class is responable for creating the IILStubEventFilter instances, and
    /// the common information of the IILStubEventFilter instances.
    /// </summary>
    internal interface IILStubEventFilterDef
    {
        /// <summary>
        /// The name of this kind of filters.
        /// </summary>
        string FilterName
        {
            get;
        }

        /// <summary>
        /// Return the list of operations that this kind of filters support.
        /// Every kind of filter has a list of operations.
        /// </summary>
        List<string> Operations
        {
            get;
        }

        /// <summary>
        /// Create the corresponding IILStubEventFilter instance.
        /// </summary>
        IILStubEventFilter CreateFilter(string operation, string value);
    }

    /// <summary>
    /// A filter, whose condition is a comparation of two integral numbers.
    /// </summary>
    abstract internal class IntegerFilter : IILStubEventFilter
    {
        private Int64 m_value;
        protected Int64 Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
            }
        }

        private string m_operation;
        protected string Operation
        {
            get
            {
                return m_operation;
            }
            set
            {
                m_operation = value;
            }
        }

        protected bool IsTrue(Int64 subject)
        {
            if (m_operation.Equals("="))
            {
                return subject == m_value;
            }
            else if (m_operation.Equals("<>"))
            {
                return subject != m_value;
            }
            else if (m_operation.Equals(">"))
            {
                return subject > m_value;
            }
            else if (m_operation.Equals(">="))
            {
                return subject >= m_value;
            }
            else if (m_operation.Equals("<"))
            {
                return subject < m_value;
            }
            else if (m_operation.Equals("<="))
            {
                return subject <= m_value;
            }
            return true;
        }

        #region IILStubEventFilter Members

        abstract public bool Match(ILStubEvent ilStubEvent);

        abstract public IILStubEventFilterDef FilterDef
        {
            get;
        }

        public string Expression
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(FilterDef.FilterName);
                sb.Append(" ");
                sb.Append(m_operation);
                sb.Append(" '");
                sb.Append(m_value);
                sb.Append("'");
                return sb.ToString();
            }
        }

        #endregion
    }

    abstract internal class IntegerFilterDef : IILStubEventFilterDef
    {
        private static List<string> s_operations = new List<string> {
            "=",
            "<>",
            ">",
            ">=",
            "<",
            "<=",
        };

        #region IILStubEventFilterDef Members

        abstract public string FilterName
        {
            get;
        }

        public List<string> Operations
        {
            get
            {
                return s_operations;
            }
        }

        abstract public IILStubEventFilter CreateFilter(string operation, string value);

        #endregion
    }

    /// <summary>
    /// A filter, whose condition is a comparation of two strings.
    /// </summary>
    abstract internal class StringFilter : IILStubEventFilter
    {

        private string m_operation;
        protected string Operation
        {
            set
            {
                m_operation = value;
            }
        }

        private string m_value;
        protected string Value
        {
            set
            {
                m_value = value;
            }
        }

        protected bool IsTrue(string subject)
        {
            if (m_operation.Equals("Equal"))
            {
                return subject.ToUpper(CultureInfo.InvariantCulture).Equals(
                    m_value.ToUpper(CultureInfo.InvariantCulture));
            }
            else if (m_operation.Equals("Contain"))
            {
                return subject.ToUpper(CultureInfo.InvariantCulture).Contains(
                    m_value.ToUpper(CultureInfo.InvariantCulture));
            }
            else if (m_operation.Equals("Not Equal"))
            {
                return !subject.ToUpper(CultureInfo.InvariantCulture).Equals(
                    m_value.ToUpper(CultureInfo.InvariantCulture));
            }
            else if (m_operation.Equals("Not Contain"))
            {
                return !subject.ToUpper(CultureInfo.InvariantCulture).Contains(
                    m_value.ToUpper(CultureInfo.InvariantCulture));
            }
            return true;
        }

        #region IILStubEventFilter Members

        abstract public bool Match(ILStubEvent ilStubEvent);

        abstract public IILStubEventFilterDef FilterDef
        {
            get;
        }

        public string Expression
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(FilterDef.FilterName);
                sb.Append(" ");
                sb.Append(m_operation);
                sb.Append(" '");
                sb.Append(m_value);
                sb.Append("'");
                return sb.ToString();
            }
        }

        #endregion
    }

    abstract internal class StringFilterDef : IILStubEventFilterDef
    {
        #region IILStubEventFilterDef Members

        abstract public string FilterName
        {
            get;
        }

        private static List<string> s_operations = new List<string> {
            "Equal",
            "Contain",
            "Not Equal",
            "Not Contain",
        };

        public List<string> Operations
        {
            get
            {
                return s_operations;
            }
        }

        abstract public IILStubEventFilter CreateFilter(string operation, string value);

        #endregion
    }

    /// <summary>
    /// A filter, whose condition is a comparation of two Process IDs.
    /// </summary>
    internal class ProcessIdFilter : IntegerFilter
    {
        public ProcessIdFilter(string operation, Int64 value)
        {
            Operation = operation;
            Value = value;
        }

        public override bool Match(ILStubEvent ilStubEvent)
        {
            int pid = ilStubEvent.ProcessId;
            return base.IsTrue(pid);
        }

        public override IILStubEventFilterDef FilterDef
        {
            get
            {
                return ProcessIdFilterDef.GetInstance();
            }
        }
    }

    internal class ProcessIdFilterDef : IntegerFilterDef
    {
        private static string s_filterName = "ProcessID";

        public override string FilterName
        {
            get
            {
                return s_filterName;
            }
        }

        private static ProcessIdFilterDef s_def = new ProcessIdFilterDef();

        private ProcessIdFilterDef() { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static ProcessIdFilterDef GetInstance()
        {
            return s_def;
        }

        public override IILStubEventFilter CreateFilter(string operation, string value)
        {
            if (operation == null)
                throw new FilterOperationIsNullException(s_filterName);
            if (value == null)
                throw new FilterValueIsNullException(s_filterName);

            List<string> operationList = Operations;
            if (operationList.Contains(operation))
            {
                Int64 integerValue;
                if (Int64.TryParse(value, out integerValue))
                {
                    return new ProcessIdFilter(operation, integerValue);
                }
                else
                {
                    throw new FilterValueNotIntegerException(s_filterName, value);
                }
            }
            else
            {
                throw new FilterOperationNotSupportException(s_filterName, operation);
            }
        }
    }

    /// <summary>
    /// A filter, whose condition is a comparation of two Process Names.
    /// </summary>
    internal class ProcessNameFilter : StringFilter
    {
        public ProcessNameFilter(string operation, string value)
        {
            Operation = operation;
            Value = value;
        }

        public override bool Match(ILStubEvent ilStubEvent)
        {
            string processName = ilStubEvent.ProcessName;
            return base.IsTrue(processName);
        }

        public override IILStubEventFilterDef FilterDef
        {
            get
            {
                return ProcessNameFilterDef.GetInstance();
            }
        }
    }

    internal class ProcessNameFilterDef : StringFilterDef
    {
        private static string s_filterName = "ProcessName";

        public override string FilterName
        {
            get
            {
                return s_filterName;
            }
        }

        private static ProcessNameFilterDef s_def = new ProcessNameFilterDef();

        private ProcessNameFilterDef() { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static ProcessNameFilterDef GetInstance()
        {
            return s_def;
        }

        public override IILStubEventFilter CreateFilter(string operation, string value)
        {
            if (operation == null)
                throw new FilterOperationIsNullException(s_filterName);
            if (value == null)
                throw new FilterValueIsNullException(s_filterName);
            List<string> operationList = Operations;
            if (operationList.Contains(operation))
            {
                return new ProcessNameFilter(operation, value);
            }
            else
            {
                throw new FilterOperationNotSupportException(s_filterName, operation);
            }
        }
    }

    /// <summary>
    /// A filter, whose condition is a comparation of two Method Names.
    /// </summary>
    internal class MethodNameFilter : StringFilter
    {
        public MethodNameFilter(string operation, string value)
        {
            Operation = operation;
            Value = value;
        }

        public override bool Match(ILStubEvent ilStubEvent)
        {
            string methodName = ilStubEvent.MethodName;
            return base.IsTrue(methodName);
        }

        public override IILStubEventFilterDef FilterDef
        {
            get
            {
                return MethodNameFilterDef.GetInstance();
            }
        }
    }

    internal class MethodNameFilterDef : StringFilterDef
    {
        private static string s_filterName = "MethodName";

        public override string FilterName
        {
            get
            {
                return s_filterName;
            }
        }

        private static MethodNameFilterDef s_def = new MethodNameFilterDef();

        private MethodNameFilterDef() { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static MethodNameFilterDef GetInstance()
        {
            return s_def;
        }

        public override IILStubEventFilter CreateFilter(string operation, string value)
        {
            if (operation == null)
                throw new FilterOperationIsNullException(s_filterName);
            if (value == null)
                throw new FilterValueIsNullException(s_filterName);
            List<string> operationList = Operations;
            if (operationList.Contains(operation))
            {
                return new MethodNameFilter(operation, value);
            }
            else
            {
                throw new FilterOperationNotSupportException(s_filterName, operation);
            }
        }
    }
}
