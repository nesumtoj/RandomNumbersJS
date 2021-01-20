using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbersAngular.Services
{
    public interface IMatchAppService : IApplicationService
    {
        Task<List<MatchDto>> GetMatchHistory();
        Task<int> PlayMatch(long matchId);
        Task<MatchDto> GetUserActiveMatch();
        Task<MatchDto> GetNextAvailableMatch();
    }
}
