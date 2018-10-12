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
    /// A block in the ILStub. For example, 
    /// "// Marshal {
    /// ...
    /// // } Marshal"
    /// </summary>
    class ILStubCodeBlock
    {
        private int m_firstCharIndex;
        private int m_lastCharIndex;

        public ILStubCodeBlock(int firstCharIndex, int lastCharIndex)
        {
            m_firstCharIndex = firstCharIndex;
            m_lastCharIndex = lastCharIndex;
        }

        public int FirstCharIndex
        {
            get
            {
                return m_firstCharIndex;
            }
        }

        public int LastCharIndex
        {
            get
            {
                return m_lastCharIndex;
            }
        }
    }
}
