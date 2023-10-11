using System.Collections.Generic;
using QualifiedAgencies.Roles.Dto;

namespace QualifiedAgencies.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
