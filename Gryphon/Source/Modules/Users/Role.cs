using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class Role
    {
        private readonly RoleDescriptor m_roleDescriptor;
        private readonly List<int> m_memberIds;

        public Role(RoleDescriptor roleDescriptor, List<int> memberIds)
        {
            m_roleDescriptor = roleDescriptor;
            m_memberIds = new List<int>();
            if (memberIds != null)
            {
                m_memberIds.AddRange(memberIds);
            }
        }

        public RoleDescriptor GetRoleDescriptor()
        {
            return m_roleDescriptor;
        }

        public IReadOnlyList<int> GetMemberIds()
        {
            return m_memberIds;
        }
    }
}
