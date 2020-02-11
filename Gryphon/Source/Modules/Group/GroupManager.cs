using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Group
{
    public class GroupManager
    {
        private readonly IGroupDescriptorValidator m_groupDescriptorValidator;

        public GroupManager(IGroupManagerConfigProvider configProvider)
        {
            if (configProvider != null)
            {
                m_groupDescriptorValidator = configProvider.GetGroupDescriptorValidator();
            }
            else
            {
                m_groupDescriptorValidator = null;
            }
        }

        public List<int> MergeGroups(IGroupDataPipe pipe, List<GroupDescriptorDetails> details)
        {
            List<GroupDescriptorData> groupDatas = new List<GroupDescriptorData>();
            foreach (GroupDescriptorDetails detail in details)
            {
                if (m_groupDescriptorValidator != null)
                {
                    bool bValid = m_groupDescriptorValidator.IsValid(detail);
                    if (!bValid)
                    {
                        groupDatas.Add(null);
                        continue;
                    }
                }

                GroupDescriptorData data = new GroupDescriptorData();
                data.Id = -1;
                data.Name = detail.GetName();
                data.Description = detail.GetDescription();
                groupDatas.Add(data);
            }

            List<int> ids = pipe.MergeGroups(groupDatas);
            if (ids.Count != details.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public void DestroyGroups(IGroupDataPipe pipe, List<int> groupIds)
        {
            pipe.DestroyGroups(groupIds);
        }

        public List<Group> GetGroups(IGroupDataPipe pipe, List<int> groupIds)
        {
            // Data is guaranteed to be returned in the correct order for valid Gryphon integrations
            // so its safe to directly map indexes

            List<Group> groups = new List<Group>();
            List<GroupDescriptorData> descriptorDatas = pipe.GetGroupDescriptors(groupIds);
            List<GroupData> memberDatas = pipe.GetGroupMembers(groupIds);
            if (descriptorDatas.Count != groupIds.Count ||
                memberDatas.Count != groupIds.Count)
            {
                throw new Exception();
            }

            for (int i = 0; i < descriptorDatas.Count; ++i)
            {
                if (descriptorDatas[i] == null || memberDatas == null)
                {
                    groups.Add(null);
                }
                else
                {
                    groups.Add(new Group(
                        new GroupDescriptor(
                            descriptorDatas[i].Id,
                            descriptorDatas[i].Name,
                            descriptorDatas[i].Description),
                        memberDatas[i].MemberIds));
                }
            }
            return groups;
        }

        public List<GroupDescriptor> GetGroupDescriptors(IGroupDataPipe pipe, List<int> groupIds)
        {
            List<GroupDescriptor> descriptors = new List<GroupDescriptor>();
            List<GroupDescriptorData> datas = pipe.GetGroupDescriptors(groupIds);
            if (datas.Count != groupIds.Count)
            {
                throw new Exception();
            }

            foreach (GroupDescriptorData data in datas)
            {
                if (data == null)
                {
                    descriptors.Add(null);
                }
                else
                {
                    descriptors.Add(
                        new GroupDescriptor(
                            data.Id,
                            data.Name,
                            data.Description));
                }
            }

            return descriptors;
        }

        public void AddMembersToGroups(IGroupDataPipe pipe, List<int> memberIds, List<int> groupIds)
        {
            pipe.AddMembersToGroups(memberIds, groupIds);
        }

        public void RemoveMembersFromGroups(IGroupDataPipe pipe, List<int> memberIds, List<int> groupIds)
        {
            pipe.RemoveMembersFromGroups(memberIds, groupIds);
        }

        public void RemoveAllMembersFromGroups(IGroupDataPipe pipe, List<int> groupIds)
        {
            pipe.RemoveAllMembersFromGroups(groupIds);
        }
    }
}
