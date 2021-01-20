using System.Threading.Tasks;
using Abp.Application.Services;
using RandomNumbersAngular.Authorization.Accounts.Dto;

namespace RandomNumbersAngular.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
