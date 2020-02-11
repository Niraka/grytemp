using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class AccountDetails
    {
        private readonly int m_iUserId;
        private readonly DateTime m_createdOn;

        public AccountDetails(int iUserId, DateTime createdOn)
        {
            m_iUserId = iUserId;
            m_createdOn = createdOn;
        }

        public int GetUserId()
        {
            return m_iUserId;
        }

        public DateTime GetCreatedOn()
        {
            return m_createdOn;
        }
    }
}
