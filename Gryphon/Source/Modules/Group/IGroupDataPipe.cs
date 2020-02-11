using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Group
{
    public interface IGroupDataPipe
    {
        List<int> MergeGroups(List<GroupDescriptorData> details);
        void DestroyGroups(List<int> groupIds);
        List<int> GetGroupIds();
        List<int> GetGroupIds(List<string> groupNames);
        List<GroupDescriptorData> GetGroupDescriptors(List<int> groupIds);
        List<GroupData> GetGroupMembers(List<int> groupIds);
        void AddMembersToGroups(List<int> memberIds, List<int> groupIds);
        void RemoveMembersFromGroups(List<int> memberIds, List<int> groupIds);
        void RemoveAllMembersFromGroups(List<int> groupIds);
    }
}
