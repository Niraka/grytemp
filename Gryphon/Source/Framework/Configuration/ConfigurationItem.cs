using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public class ConfigurationItem<T>
    {
        private readonly int m_iId;
        private readonly string m_sName;
        private readonly string m_sDisplayName;
        private readonly string m_sDescription;
        private T m_value;
        private readonly bool m_bEncryptAtRest;

        public ConfigurationItem()
        {
            m_iId = -1;
            m_sName = string.Empty;
            m_sDisplayName = string.Empty;
            m_sDescription = string.Empty;
            m_value = default(T);
            m_bEncryptAtRest = false;
        }

        public ConfigurationItem(int iId, ConfigurationItemDetails<T> details)
        {
            m_iId = iId;
            m_sName = details.GetName();
            m_sDisplayName = details.GetDisplayName();
            m_sDescription = details.GetDescription();
            m_value = details.GetValue();
            m_bEncryptAtRest = details.IsEncryptedAtRest();
        }

        public ConfigurationItem(int iId, string sName, string sDisplayName, 
            string sDescription, T value, bool bEncryptAtRest)
        {
            m_iId = iId;
            m_sName = sName;
            m_sDisplayName = sDisplayName;
            m_sDescription = sDescription;
            m_value = value;
            m_bEncryptAtRest = bEncryptAtRest;
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
