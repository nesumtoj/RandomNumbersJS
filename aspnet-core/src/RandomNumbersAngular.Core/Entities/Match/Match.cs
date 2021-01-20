using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomNumbersAngular.Entities
{
    public class Match : AuditedEntity<long>
    {
        public DateTime ExpiryDate { get; set; }

        public virtual ICollection<LnkMatchUser> Participants { get; set; }
    }
}
