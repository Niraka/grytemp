using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserAlias
    {
        private readonly int m_iId;
        private readonly int m_iUserId;
        private readonly DateTime m_createdDate;
        private readonly DateTime m_deletedDate;
        private readonly string m_sAlias;

        public UserAlias(int iId, int iUserId, DateTime createdDate,
            DateTime deletedDate, string sAlias)
        {
            m_iId = iId;
            m_iUserId = iUserId;
            m_createdDate = createdDate;
            m_deletedDate = deletedDate;
            m_sAlias = sAlias;
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

        public string GetAlias()
        {
            return m_sAlias;
        }
    }
}
