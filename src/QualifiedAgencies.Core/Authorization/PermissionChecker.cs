using Abp.Authorization;
using QualifiedAgencies.Authorization.Roles;
using QualifiedAgencies.Authorization.Users;

namespace QualifiedAgencies.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
