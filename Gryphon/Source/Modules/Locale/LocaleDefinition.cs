using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Locale
{
    public class LocaleDefinition
    {
        private readonly int m_iId;
        private readonly string m_sName;
        private readonly string m_sCode;
        private readonly string m_sFamilyName;
        private readonly string m_sLocalisedName;

        public LocaleDefinition()
        {
            m_iId = -1;
            m_sName = string.Empty;
            m_sCode = string.Empty;
            m_sFamilyName = string.Empty;
            m_sLocalisedName = string.Empty;
        }

        public LocaleDefinition(int iId, string sName, string sCode, string sFamilyName,
            string sLocalisedName)
        {
            m_iId = iId;
            m_sName = sName;
            m_sCode = sCode;
            m_sFamilyName = sFamilyName;
            m_sLocalisedName = sLocalisedName;
        }

        public int GetId()
        {
            return m_iId;
        }

        public string GetName()
        {
            return m_sName;
        }

        public string GetCode()
        {
            return m_sCode;
        }

        public string GetFamilyName()
        {
            return m_sFamilyName;
        }
        
        public string GetLocalisedName()
        {
            return m_sLocalisedName;
        }
    }
}
