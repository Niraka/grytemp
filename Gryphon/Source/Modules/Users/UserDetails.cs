using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserDetails
    {
        private readonly string m_sName;
        private readonly DateTime m_createdDate;

        public UserDetails(string sName, DateTime createdDate)
        {
            m_sName = sName;
            m_createdDate = createdDate;
        }
        
        public string GetName()
        {
            return m_sName;
        }

        public DateTime GetCreatedDate()
        {
            return m_createdDate;
        }
    }
}
