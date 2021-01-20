using System.Threading.Tasks;
using RandomNumbersAngular.Configuration.Dto;

namespace RandomNumbersAngular.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
