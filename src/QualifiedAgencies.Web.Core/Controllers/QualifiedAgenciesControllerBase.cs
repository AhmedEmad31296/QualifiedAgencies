using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace QualifiedAgencies.Controllers
{
    public abstract class QualifiedAgenciesControllerBase: AbpController
    {
        protected QualifiedAgenciesControllerBase()
        {
            LocalizationSourceName = QualifiedAgenciesConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
