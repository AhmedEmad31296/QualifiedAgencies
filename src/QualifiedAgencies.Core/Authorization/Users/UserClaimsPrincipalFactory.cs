using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using QualifiedAgencies.Authorization.Roles;
using Abp.Domain.Uow;
using System.Threading.Tasks;
using System.Security.Claims;
using Abp.Runtime.Security;
using Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QualifiedAgencies.Authorization.Users
{
    public class UserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>
    {
        private readonly IRepository<User, long> _UserRepository;
        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            IRepository<User, long> userRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                  userManager,
                  roleManager,
                  optionsAccessor,
                  unitOfWorkManager)
        {
            _UserRepository = userRepository;
        }
        //public override async Task<ClaimsPrincipal> CreateAsync(User user)
        //{
        //    var principal = await base.CreateAsync(user);
        //    var _user = await _UserRepository.GetAll().Where(x => x.Id == user.Id).Select(x => new
        //    {
        //        x.Id,
        //        x.Name,
        //        x.UserName,
        //        x.FullName,
        //        x.EmailAddress
        //    }).FirstOrDefaultAsync();
        //    if (_user != null)
        //    {
        //        ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
        //                                              new Claim(QualifiedAgenciesConsts.AppClaimTypes, _user.Id.ToString()),
        //                                           });
        //        return principal;
        //    }
        //    return principal;
        //}
    }
}
