using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RandomNumbersAngular.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNumbersAngular.Services
{
    [AutoMap(typeof(Match))]
    public class MatchDto : AuditedEntityDto<long>
    {
        public DateTime ExpiryDate { get; set; }

        public List<ParticipantDto> Participants { get; set; }

        public ParticipantDto Winner => Participants.OrderBy(x => x.RandomNumber).ToList().FirstOrDefault();
    }
}
