using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using RandomNumbersAngular.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RandomNumbersAngular.Entities
{
    public class LnkMatchUser : AuditedEntity<long>
    {
        public long MatchId { get; set; }
        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; }
        
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        //[NotMapped]
        //public string UserFullName => User.Name + " " + User.Surname;

        public int RandomNumber { get; set; }
    }
}
