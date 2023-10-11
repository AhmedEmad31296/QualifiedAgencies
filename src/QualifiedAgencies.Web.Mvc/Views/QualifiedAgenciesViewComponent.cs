using Abp.AspNetCore.Mvc.ViewComponents;

namespace QualifiedAgencies.Web.Views
{
    public abstract class QualifiedAgenciesViewComponent : AbpViewComponent
    {
        protected QualifiedAgenciesViewComponent()
        {
            LocalizationSourceName = QualifiedAgenciesConsts.LocalizationSourceName;
        }
    }
}
