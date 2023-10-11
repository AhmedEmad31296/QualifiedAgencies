using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QualifiedAgencies.Authorization;

namespace QualifiedAgencies
{
    [DependsOn(
        typeof(QualifiedAgenciesCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class QualifiedAgenciesApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QualifiedAgenciesAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QualifiedAgenciesApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
