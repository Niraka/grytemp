using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Locale
{
    public class TextDefinition
    {
        private readonly int m_iId;
        private readonly string m_sName;
        private readonly string m_sDescription;

        public TextDefinition()
        {
            m_iId = -1;
            m_sName = string.Empty;
            m_sDescription = string.Empty;
        }

        public TextDefinition(int iId, string sName, string sDescription)
        {
            m_iId = iId;
            m_sName = sName;
            m_sDescription = sDescription;
        }

        public int GetId()
        {
            return m_iId;
        }
        
        public string GetName()
        {
            return m_sName;
        }

        public string GetDescription()
        {
            return m_sDescription;
        }
    }
}
