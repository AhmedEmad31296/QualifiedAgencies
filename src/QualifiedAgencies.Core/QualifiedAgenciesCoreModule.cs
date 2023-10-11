using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using QualifiedAgencies.Authorization.Roles;
using QualifiedAgencies.Authorization.Users;
using QualifiedAgencies.Configuration;
using QualifiedAgencies.Localization;
using QualifiedAgencies.MultiTenancy;
using QualifiedAgencies.Timing;

namespace QualifiedAgencies
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class QualifiedAgenciesCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            QualifiedAgenciesLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = QualifiedAgenciesConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "En", "famfamfam-flags en"));
            Configuration.Localization.Languages.Add(new LanguageInfo("ar-eg", "العربية", "famfamfam-flags ar", true));

            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = QualifiedAgenciesConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = QualifiedAgenciesConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QualifiedAgenciesCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
