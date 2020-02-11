using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    // Account name is the login name. Its probably an email address, but could just be a name. If its an 
    // email address its probably also listed in the email address records.
    public class User
    {
        private readonly int m_iId;
        private readonly string m_sName;
        private readonly DateTime m_createdDate;

        public User(int iId, string sName, DateTime createdDate)
        {
            m_iId = iId;
            m_sName = sName;
            m_createdDate = createdDate;
        }

        public int GetId()
        {
            return m_iId;
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
