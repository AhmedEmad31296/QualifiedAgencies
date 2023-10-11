using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QualifiedAgencies.EntityFrameworkCore;
using QualifiedAgencies.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace QualifiedAgencies.Web.Tests
{
    [DependsOn(
        typeof(QualifiedAgenciesWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class QualifiedAgenciesWebTestModule : AbpModule
    {
        public QualifiedAgenciesWebTestModule(QualifiedAgenciesEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QualifiedAgenciesWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(QualifiedAgenciesWebMvcModule).Assembly);
        }
    }
}