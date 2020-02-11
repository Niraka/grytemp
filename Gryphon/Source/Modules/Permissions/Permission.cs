using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Permissions
{
    public class Permission
    {
        private readonly int m_iId;
        private readonly string m_sName;
        private readonly string m_sDescription;

        public Permission(int iId, string sName, string sDescription)
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
