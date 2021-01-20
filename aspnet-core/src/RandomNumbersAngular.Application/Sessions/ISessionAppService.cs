using System.Threading.Tasks;
using Abp.Application.Services;
using RandomNumbersAngular.Sessions.Dto;

namespace RandomNumbersAngular.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
