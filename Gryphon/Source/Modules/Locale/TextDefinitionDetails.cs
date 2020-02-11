using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Locale
{
    public class TextDefinitionDetails
    {
        private readonly string m_sName;
        private readonly string m_sDescription;

        public TextDefinitionDetails()
        {
            m_sName = string.Empty;
            m_sDescription = string.Empty;
        }

        public TextDefinitionDetails(string sName, string sDescription)
        {
            m_sName = sName;
            m_sDescription = sDescription;
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
