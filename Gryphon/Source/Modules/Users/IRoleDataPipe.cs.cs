using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Users
{
    public interface IRoleDataPipe : IIntegration
    {
        Task<List<int>> MergeRoles(List<RoleDescriptorData> roleDescriptorDetails);
        Task DestroyRoles(List<int> roleIds);
        Task<List<int>> GetRoleIds();
        Task<List<int>> GetRoleIds(List<string> roleNames);
        Task<List<RoleDescriptorData>> GetRoleDescriptors(List<int> roleIds);
        Task<List<RoleData>> GetRoles(List<int> roleIds);
        Task AddMembersToRoles(List<int> roleIds, List<int> memberIds);
        Task RemoveMembersFromRoles(List<int> roleIds, List<int> memberIds);
        Task RemoveAllMembersFromRoles(List<int> roleIds);
    }
}
