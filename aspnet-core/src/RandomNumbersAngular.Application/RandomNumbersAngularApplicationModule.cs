using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RandomNumbersAngular.Authorization;

namespace RandomNumbersAngular
{
    [DependsOn(
        typeof(RandomNumbersAngularCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class RandomNumbersAngularApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<RandomNumbersAngularAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(RandomNumbersAngularApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
