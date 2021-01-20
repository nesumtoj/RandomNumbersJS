using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RandomNumbersAngular.Configuration;
using RandomNumbersAngular.EntityFrameworkCore;
using RandomNumbersAngular.Migrator.DependencyInjection;

namespace RandomNumbersAngular.Migrator
{
    [DependsOn(typeof(RandomNumbersAngularEntityFrameworkModule))]
    public class RandomNumbersAngularMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public RandomNumbersAngularMigratorModule(RandomNumbersAngularEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(RandomNumbersAngularMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                RandomNumbersAngularConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(RandomNumbersAngularMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
