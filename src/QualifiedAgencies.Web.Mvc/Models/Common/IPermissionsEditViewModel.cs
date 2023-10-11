using System.Collections.Generic;
using QualifiedAgencies.Roles.Dto;

namespace QualifiedAgencies.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}