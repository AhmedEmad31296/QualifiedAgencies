using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QualifiedAgencies.Configuration;

namespace QualifiedAgencies.Web.Host.Startup
{
    [DependsOn(
       typeof(QualifiedAgenciesWebCoreModule))]
    public class QualifiedAgenciesWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QualifiedAgenciesWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QualifiedAgenciesWebHostModule).GetAssembly());
        }
    }
}
