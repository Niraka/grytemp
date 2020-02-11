using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Integration
{
    public class IntegrationSourceDescriptor
    {
        private readonly string m_sName;
        private readonly string m_sDescription;
        private readonly Version m_version;

        public IntegrationSourceDescriptor()
        {
            m_sName = string.Empty;
            m_sDescription = string.Empty;
            m_version = new Version(0, 0, 0, 0);
        }

        public IntegrationSourceDescriptor(string sName, string sDescription, Version version)
        {
            m_sName = sName;
            m_sDescription = sDescription;
            m_version = version;
        }

        public string GetName()
        {
            return m_sName;
        }

        public string GetDescription()
        {
            return m_sDescription;
        }

        public Version GetVersion()
        {
            return m_version;
        }
    }
}
