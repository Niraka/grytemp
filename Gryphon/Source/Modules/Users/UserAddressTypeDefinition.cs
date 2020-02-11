using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    class UserAddressTypeDefinition
    {
        private readonly int m_iId;
        private readonly string m_sName;

        public UserAddressTypeDefinition(int iId, string sName)
        {
            m_iId = iId;
            m_sName = sName;
        }

        public int GetId()
        {
            return m_iId;
        }

        public string GetName()
        {
            return m_sName;
        }
    }
}
