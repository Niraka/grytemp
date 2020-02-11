using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public class ConfigurationItemDetails<T>
    {
        private readonly string m_sName;
        private readonly string m_sDisplayName;
        private readonly string m_sDescription;
        private T m_value;
        private readonly bool m_bEncryptAtRest;

        public ConfigurationItemDetails()
        {
            m_sName = string.Empty;
            m_sDisplayName = string.Empty;
            m_sDescription = string.Empty;
            m_value = default(T);
            m_bEncryptAtRest = false;
        }

        public ConfigurationItemDetails(string sName, string sDisplayName,
            string sDescription, T value, bool bEncryptAtRest)
        {
            m_sName = sName;
            m_sDisplayName = sDisplayName;
            m_sDescription = sDescription;
            m_value = value;
            m_bEncryptAtRest = bEncryptAtRest;
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

        public T GetValue()
        {
            return m_value;
        }

        public bool IsEncryptedAtRest()
        {
            return m_bEncryptAtRest;
        }
    }
}
