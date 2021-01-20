using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace RandomNumbersAngular.Controllers
{
    public abstract class RandomNumbersAngularControllerBase: AbpController
    {
        protected RandomNumbersAngularControllerBase()
        {
            LocalizationSourceName = RandomNumbersAngularConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
