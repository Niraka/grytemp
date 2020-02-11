using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserPhoneNumber
    {
        private readonly int m_iId;
        private readonly int m_iUserId;
        private readonly DateTime m_createdDate;
        private readonly DateTime m_deletedDate;
        private readonly string m_sNumber;

        public UserPhoneNumber(int iId, int iUserId, DateTime createdDate,
            DateTime deletedDate, string sNumber)
        {
            m_iId = iId;
            m_iUserId = iUserId;
            m_createdDate = createdDate;
            m_deletedDate = deletedDate;
            m_sNumber = sNumber;
        }

        public int GetId()
        {
            return m_iId;
        }

        public int GetUserId()
        {
            return m_iUserId;
        }

        public DateTime GetCreatedDate()
        {
            return m_createdDate;
        }

        public DateTime GetDeletedDate()
        {
            return m_deletedDate;
        }

        public string GetPhoneNumber()
        {
            return m_sNumber;
        }
    }
}
