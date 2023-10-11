using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QualifiedAgencies.Configuration;

namespace QualifiedAgencies.Web.Startup
{
    [DependsOn(typeof(QualifiedAgenciesWebCoreModule))]
    public class QualifiedAgenciesWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QualifiedAgenciesWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<QualifiedAgenciesNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QualifiedAgenciesWebMvcModule).GetAssembly());
        }
    }
}
