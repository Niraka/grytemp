using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public class ConfigurationSource
    {
        private readonly int m_iId;
        private readonly string m_sName;
        private readonly string m_sDisplayName;
        private readonly string m_sDescription;

        public ConfigurationSource()
        {
            m_iId = -1;
            m_sName = string.Empty;
            m_sDisplayName = string.Empty;
            m_sDescription = string.Empty;
        }

        public ConfigurationSource(int iId, string sName, string sDisplayName, 
            string sDescription)
        {
            m_iId = iId;
            m_sName = sName;
            m_sDisplayName = sDisplayName;
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
