using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Permissions
{
    internal class PermissionModule
    {
        private readonly IPermissionValidator m_permissionValidator;
        private readonly IPermissionTargetValidator m_permissionTargetValidator;

        public PermissionModule(IPermissionModuleConfigProvider configProvider)
        {
            if (configProvider == null)
            {
                throw new Exception();
            }

            m_permissionValidator = configProvider.GetPermissionValidator();
            m_permissionTargetValidator = configProvider.GetPermissionTargetValidator();

            if (m_permissionValidator == null)
            {
                throw new Exception();
            }
            if (m_permissionTargetValidator == null)
            {
                throw new Exception();
            }
        }

        public async Task<List<int>> MergePermissions(int iContextId, IPermissionDataPipe pipe, List<PermissionDetails> permissionDetails)
        {
            List<PermissionData> permissionDatas = new List<PermissionData>();
            foreach (PermissionDetails details in permissionDetails)
            {
                Tools.ValidationResult result = m_permissionValidator.IsValid(details);
                if (!result.WasValid())
                {
                    permissionDatas.Add(null);
                }
                else
                {
                    PermissionData data = new PermissionData();
                    data.Id = -1;
                    data.ContextId = iContextId;
                    data.Name = details.GetName();
                    data.Description = details.GetDescription();
                }
            }

            List<int> ids = await pipe.MergePermissions(permissionDatas);
            if (ids.Count != permissionDatas.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public async Task<List<int>> MergePermissionTargets(int iContextId, IPermissionDataPipe pipe, List<PermissionTargetDetails> permissionTargetDetails)
        {
            List<PermissionTargetData> permissionTargetDatas = new List<PermissionTargetData>();
            foreach (PermissionTargetDetails details in permissionTargetDetails)
            {
                Tools.ValidationResult result = m_permissionTargetValidator.IsValid(details);
                if (!result.WasValid())
                {
                    permissionTargetDatas.Add(null);
                }
                else
                {
                    PermissionTargetData data = new PermissionTargetData();
                    data.Id = -1;
                    data.ContextId = iContextId;
                    data.Name = details.GetName();
                    permissionTargetDatas.Add(data);
                }
            }

            List<int> ids = await pipe.MergePermissionTargets(permissionTargetDatas);
            if (ids.Count != permissionTargetDatas.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public Task<List<int>> GetPermissionIds(IPermissionDataPipe pipe)
        {
            return pipe.GetPermissionIds();
        }

        public async Task<List<int>> GetPermissionIds(int iContextId, IPermissionDataPipe pipe, List<string> permissionNames)
        {
            List<int> ids = await pipe.GetPermissionIds(iContextId, permissionNames);
            if (ids.Count != permissionNames.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public Task<List<int>> GetPermissionTargetIds(IPermissionDataPipe pipe)
        {
            return pipe.GetPermissionTargetIds();
        }

        public async Task<List<int>> GetPermissionTargetIds(int iContextId, IPermissionDataPipe pipe, List<string> permissionTargetNames)
        {
            List<int> ids = await pipe.GetPermissionTargetIds(iContextId, permissionTargetNames);
            if (ids.Count != permissionTargetNames.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public async Task<List<Permission>> GetPermissions(IPermissionDataPipe pipe, List<int> permissionIds)
        {
            List<PermissionData> permissionDatas = await pipe.GetPermissions(permissionIds);
            if (permissionDatas.Count != permissionIds.Count)
            {
                throw new Exception();
            }

            List<Permission> permissions = new List<Permission>();
            foreach (PermissionData data in permissionDatas)
            {
                if (data == null)
                {
                    permissions.Add(null);
                }
                else
                {
                    permissions.Add(new Permission(data.Id, data.Name, data.Description));
                }
            }

            return permissions;
        }

        public async Task<List<PermissionTarget>> GetPermissionTargets(IPermissionDataPipe pipe, List<int> permissionIds)
        {
            List<PermissionTargetData> permissionTargetDatas = await pipe.GetPermissionTargets(permissionIds);
            if (permissionTargetDatas.Count != permissionIds.Count)
            {
                throw new Exception();
            }

            List<PermissionTarget> targets = new List<PermissionTarget>();
            foreach (PermissionTargetData data in permissionTargetDatas)
            {
                if (targets == null)
                {
                    targets.Add(null);
                }
                else
                {
                    targets.Add(new PermissionTarget(data.Id, data.Name));
                }
            }

            return targets;
        }

        public Task SetPermissions(IPermissionDataPipe pipe, List<int> permissionIds, List<int> permissionTargetIds, bool bGranted)
        {
            return pipe.SetPermissions(permissionIds, permissionTargetIds, bGranted);
        }

        public async Task<List<bool>> GetPermissions(IPermissionDataPipe pipe, List<int> permissionIds, List<int> permissionTargetIds)
        {
            List<bool> bools = await pipe.GetPermissions(permissionIds, permissionTargetIds);
            if (bools.Count != permissionIds.Count * permissionTargetIds.Count)
            {
                throw new Exception();
            }

            return bools;
        }
    }
}

