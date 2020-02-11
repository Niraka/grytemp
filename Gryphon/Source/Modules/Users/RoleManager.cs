using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Users
{
    internal class RoleManager
    {
        private readonly IRoleDescriptorValidator m_roleDescriptorDetailsValidator;

        public RoleManager(IRoleManagerConfigProvider configProvider)
        {
            if (configProvider == null)
            {
                throw new Exception();
            }

            m_roleDescriptorDetailsValidator = configProvider.GetRoleValidator();

            if (m_roleDescriptorDetailsValidator == null)
            {
                throw new Exception();
            }
        }

        public async Task<List<int>> MergeRoles(int iContextId, IRoleDataPipe pipe, 
            List<RoleDescriptorDetails> roleDescriptorDetails)
        {
            List<RoleDescriptorData> descriptorDatas = new List<RoleDescriptorData>();
            foreach (RoleDescriptorDetails details in roleDescriptorDetails)
            {
                Tools.ValidationResult result = m_roleDescriptorDetailsValidator.IsValid(details);
                if (result.WasValid())
                {
                    RoleDescriptorData data = new RoleDescriptorData();
                    data.Id = -1;
                    data.ContextId = iContextId;
                    data.Name = details.GetName();
                    data.Description = details.GetDescription();
                    descriptorDatas.Add(data);
                }
                else
                {
                    descriptorDatas.Add(null);
                }
            }

            List<int> ids = await pipe.MergeRoles(descriptorDatas);
            if (ids.Count != roleDescriptorDetails.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public Task DestroyRoles(IRoleDataPipe pipe, List<int> roleIds)
        {
            return pipe.DestroyRoles(roleIds);
        }

        public Task<List<int>> GetRoleIds(IRoleDataPipe pipe)
        {
            return pipe.GetRoleIds();
        }

        public async Task<List<int>> GetRoleIds(IRoleDataPipe pipe, List<string> roleNames)
        {
            List<int> ids = await pipe.GetRoleIds(roleNames);
            if (ids.Count != roleNames.Count)
            {
                throw new Exception();
            }

            return ids; 
        }

        public async Task<List<RoleDescriptor>> GetRoleDescriptors(IRoleDataPipe pipe, List<int> roleIds)
        {
            List<RoleDescriptorData> roleDescriptorDatas = await pipe.GetRoleDescriptors(roleIds);
            if (roleDescriptorDatas.Count != roleIds.Count)
            {
                throw new Exception();
            }

            List<RoleDescriptor> roleDescriptors = new List<RoleDescriptor>();
            foreach (RoleDescriptorData data in roleDescriptorDatas)
            {
                if (data == null)
                {
                    roleDescriptors.Add(null);
                }
                else
                {
                    roleDescriptors.Add(
                        new RoleDescriptor(
                            data.Id, 
                            data.Name, 
                            data.Description));
                }
            }

            return roleDescriptors;
        }

        public async Task<List<Role>> GetRoles(IRoleDataPipe pipe, List<int> roleIds)
        {
            List<RoleData> roleDatas = await pipe.GetRoles(roleIds);
            if (roleDatas.Count != roleIds.Count)
            {
                throw new Exception();
            }

            List<Role> roles = new List<Role>();
            foreach (RoleData data in roleDatas)
            {
                if (data == null)
                {
                    roles.Add(null);
                }
                else
                {
                    roles.Add(
                        new Role(
                            new RoleDescriptor(
                                data.RoleDescriptor.Id,
                                data.RoleDescriptor.Name,
                                data.RoleDescriptor.Description),
                            data.MemberIds));
                }
                
            }

            return roles;
        }

        public Task AddMembersToRoles(IRoleDataPipe pipe, List<int> roleIds, List<int> memberIds)
        {
            return pipe.AddMembersToRoles(roleIds, memberIds);
        }

        public Task RemoveMembersFromRoles(IRoleDataPipe pipe, List<int> roleIds, List<int> memberIds)
        {
            return pipe.RemoveMembersFromRoles(roleIds, memberIds);
        }

        public Task RemoveAllMembersFromRoles(IRoleDataPipe pipe, List<int> roleIds)
        {
            return pipe.RemoveAllMembersFromRoles(roleIds);
        }
    }
}
