using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using RandomNumbersAngular.Configuration.Dto;

namespace RandomNumbersAngular.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : RandomNumbersAngularAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
