using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserAliasDetails
    {
        private readonly int m_iUserId;
        private readonly string m_sAlias;

        public UserAliasDetails(int iUserId, string sAlias)
        {
            m_iUserId = iUserId;
            m_sAlias = sAlias;
        }
        
        public int GetUserId()
        {
            return m_iUserId;
        }

        public string GetAlias()
        {
            return m_sAlias;
        }
    }
}
