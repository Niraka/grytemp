using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public class ConfigurationSourceDetails
    {
        private readonly string m_sName;
        private readonly string m_sDisplayName;
        private readonly string m_sDescription;

        public ConfigurationSourceDetails()
        {
            m_sName = string.Empty;
            m_sDisplayName = string.Empty;
            m_sDescription = string.Empty;
        }

        public ConfigurationSourceDetails(string sName, string sDisplayName,
            string sDescription)
        {
            m_sName = sName;
            m_sDisplayName = sDisplayName;
            m_sDescription = sDescription;
        }

        public string GetName()
        {
            return m_sName;
        }

        public string GetDisplayName()
        {
            return m_sDisplayName;
        }

        public string GetDescription()
        {
            return m_sDescription;
        }
    }
}
