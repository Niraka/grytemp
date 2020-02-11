using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Group
{
    public class Group
    {
        private readonly GroupDescriptor m_descriptor;
        private readonly List<int> m_memberIds;

        public Group()
        {
            m_descriptor = new GroupDescriptor();
            m_memberIds = new List<int>();
        }

        public Group(GroupDescriptor descriptor, List<int> memberIds)
        {
            m_descriptor = descriptor ?? new GroupDescriptor();
            m_memberIds = new List<int>();
            if (memberIds != null)
            {
                m_memberIds.AddRange(memberIds);
            }
        }

        public GroupDescriptor GetDescriptor()
        {
            return m_descriptor;
        }

        public int GetId()
        {
            return m_descriptor.GetId();
        }

        public List<int> GetMemberIds()
        {
            List<int> ids = new List<int>();
            ids.AddRange(m_memberIds);
            return ids;
        }
    }
}
