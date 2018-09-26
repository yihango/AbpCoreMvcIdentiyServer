using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreMvcIdentiyServer.Configuration;
using AbpCoreMvcIdentiyServer.EntityFrameworkCore;
using AbpCoreMvcIdentiyServer.Migrator.DependencyInjection;

namespace AbpCoreMvcIdentiyServer.Migrator
{
    [DependsOn(typeof(AbpCoreMvcIdentiyServerEntityFrameworkModule))]
    public class AbpCoreMvcIdentiyServerMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreMvcIdentiyServerMigratorModule(AbpCoreMvcIdentiyServerEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AbpCoreMvcIdentiyServerMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AbpCoreMvcIdentiyServerConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreMvcIdentiyServerMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
