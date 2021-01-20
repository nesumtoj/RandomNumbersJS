using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RandomNumbersAngular.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomNumbersAngular.Services
{
    [AutoMap(typeof(LnkMatchUser))]
    public class ParticipantDto : AuditedEntityDto<long>
    {
        public long MatchId { get; set; }

        public long UserId { get; set; }

        //public string UserFullName { get; set; }

        public int RandomNumber { get; set; }
    }
}
