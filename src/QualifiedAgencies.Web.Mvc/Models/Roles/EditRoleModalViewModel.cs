using Abp.AutoMapper;
using QualifiedAgencies.Roles.Dto;
using QualifiedAgencies.Web.Models.Common;

namespace QualifiedAgencies.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
