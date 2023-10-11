using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QualifiedAgencies.Configuration;
using QualifiedAgencies.EntityFrameworkCore;
using QualifiedAgencies.Migrator.DependencyInjection;

namespace QualifiedAgencies.Migrator
{
    [DependsOn(typeof(QualifiedAgenciesEntityFrameworkModule))]
    public class QualifiedAgenciesMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public QualifiedAgenciesMigratorModule(QualifiedAgenciesEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(QualifiedAgenciesMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                QualifiedAgenciesConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QualifiedAgenciesMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
