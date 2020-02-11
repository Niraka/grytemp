using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gryphon.Modules.Permissions
{
    public interface IPermissionDataPipe
    {
        Task<List<int>> MergePermissions(List<PermissionData> permissionDatas);
        Task<List<int>> MergePermissionTargets(List<PermissionTargetData> permissionTargetDatas);
        Task<List<int>> GetPermissionIds();
        Task<List<int>> GetPermissionIds(int iContextId, List<string> permissionNames);
        Task<List<int>> GetPermissionTargetIds();
        Task<List<int>> GetPermissionTargetIds(int iContextId, List<string> permissionTargetNames);
        Task<List<PermissionData>> GetPermissions(List<int> permissionIds);
        Task<List<PermissionTargetData>> GetPermissionTargets(List<int> permissionIds);
        Task SetPermissions(List<int> permissionIds, List<int> permissionTargetIds, bool bGranted);
        Task<List<bool>> GetPermissions(List<int> permissionIds, List<int> permissionTargetIds);
    }
}
