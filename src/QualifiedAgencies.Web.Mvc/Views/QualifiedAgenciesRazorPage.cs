using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace QualifiedAgencies.Web.Views
{
    public abstract class QualifiedAgenciesRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected QualifiedAgenciesRazorPage()
        {
            LocalizationSourceName = QualifiedAgenciesConsts.LocalizationSourceName;
        }
    }
}
