using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class Account
    {
        private readonly int m_iId;
        private readonly int m_iUserId;
        private readonly List<int> m_roleIds;
        private readonly DateTime m_createdOn;

        public Account(int iId, int iUserId, List<int> roleIds, DateTime createdOn)
        {
            m_iId = iId;
            m_iUserId = iUserId;
            m_createdOn = createdOn;
            m_roleIds = new List<int>();
            m_roleIds.AddRange(roleIds);
        }

        public int GetId()
        {
            return m_iId;
        }

        public int GetUserId()
        {
            return m_iUserId;
        }

        public IReadOnlyList<int> GetRoleIds()
        {
            return m_roleIds;
        }

        public DateTime GetCreatedOn()
        {
            return m_createdOn;
        }
    }
}
