using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RandomNumbersAngular.Configuration;

namespace RandomNumbersAngular.Web.Host.Startup
{
    [DependsOn(
       typeof(RandomNumbersAngularWebCoreModule))]
    public class RandomNumbersAngularWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public RandomNumbersAngularWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RandomNumbersAngularWebHostModule).GetAssembly());
        }
    }
}
