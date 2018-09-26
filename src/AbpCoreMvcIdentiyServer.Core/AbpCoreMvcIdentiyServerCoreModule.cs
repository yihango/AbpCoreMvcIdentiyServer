using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using AbpCoreMvcIdentiyServer.Authorization.Roles;
using AbpCoreMvcIdentiyServer.Authorization.Users;
using AbpCoreMvcIdentiyServer.Configuration;
using AbpCoreMvcIdentiyServer.Localization;
using AbpCoreMvcIdentiyServer.MultiTenancy;
using AbpCoreMvcIdentiyServer.Timing;

namespace AbpCoreMvcIdentiyServer
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpCoreMvcIdentiyServerCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AbpCoreMvcIdentiyServerLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AbpCoreMvcIdentiyServerConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreMvcIdentiyServerCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
