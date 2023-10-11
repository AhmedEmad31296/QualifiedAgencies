using System.Collections.Generic;
using QualifiedAgencies.Roles.Dto;

namespace QualifiedAgencies.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
