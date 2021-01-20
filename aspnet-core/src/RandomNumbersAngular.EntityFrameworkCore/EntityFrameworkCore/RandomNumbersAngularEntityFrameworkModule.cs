using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using RandomNumbersAngular.EntityFrameworkCore.Seed;

namespace RandomNumbersAngular.EntityFrameworkCore
{
    [DependsOn(
        typeof(RandomNumbersAngularCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class RandomNumbersAngularEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<RandomNumbersAngularDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        RandomNumbersAngularDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        RandomNumbersAngularDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RandomNumbersAngularEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
