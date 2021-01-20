using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using RandomNumbersAngular.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbersAngular.Services
{
    public class MatchAppService : ApplicationService, IMatchAppService
    {
        private readonly IRepository<Match, long> _repository;
        private readonly IRepository<LnkMatchUser, long> _lnkMatchUserRepository;

        public MatchAppService(
            IRepository<Match, long> repository,
            IRepository<LnkMatchUser, long> lnkMatchUserRepository
            )
        {
            _repository = repository;
            _lnkMatchUserRepository = lnkMatchUserRepository;
        }

        public async Task<MatchDto> GetNextAvailableMatch()
        {
            var availableMatch = await _repository
                .GetAll()
                .Where(x => DateTime.Compare(x.ExpiryDate, DateTime.Now) > 0)
                .OrderBy(x => x.ExpiryDate)
                .Select(x => ObjectMapper.Map<MatchDto>(x))
                .FirstOrDefaultAsync();

            return availableMatch;
        }

        public async Task<List<MatchDto>> GetMatchHistory()
        {
            var expiredMatches = await _repository
                .GetAllIncluding(x => x.Participants)
                .Where(x => DateTime.Compare(x.ExpiryDate, DateTime.Now) < 0)
                .Select(x => ObjectMapper.Map<MatchDto>(x))
                .ToListAsync();

            return expiredMatches;
        }

        [AbpAuthorize]
        public async Task<MatchDto> GetUserActiveMatch()
        {
            var activeMatch = await _lnkMatchUserRepository
                .GetAllIncluding(x => x.Match)
                .Where(x => x.UserId == AbpSession.UserId.Value)
                .Where(x => DateTime.Compare(x.Match.ExpiryDate, DateTime.Now) > 0)
                .FirstOrDefaultAsync();

            return (activeMatch != null) ? ObjectMapper.Map<MatchDto>(activeMatch.Match) : null;
        }

        [AbpAuthorize]
        public async Task<int> PlayMatch(long matchId)
        {
            // Validate match and user
            var activeMatch = await GetUserActiveMatch();

            if (activeMatch != null)
                throw new UserFriendlyException(409, "You cannot participate to another match when the previous match is not yet finished");

            var match = await _repository.FirstOrDefaultAsync(x => x.Id == matchId);

            if (match == null)
                throw new UserFriendlyException(400, "The selected match does not exist");

            if (DateTime.Compare(match.ExpiryDate, DateTime.Now) < 0)
                throw new UserFriendlyException(403, "The match you are trying to participate is finished");

            // Generate random number for the user
            Random random = new Random();
            int randomNumber = random.Next(0, 100);

            // participate the user
            await _lnkMatchUserRepository.InsertAsync(new LnkMatchUser()
            {
                MatchId = match.Id,
                UserId = AbpSession.UserId.Value,
                RandomNumber = randomNumber
            });

            return randomNumber;
        }
        
    }
}
