using Abp.Domain.Entities.Auditing;

using QualifiedAgencies.Common;
using QualifiedAgencies.Lookups;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifiedAgencies.Entities
{
    [Table("EligibleEntities")]
    public class EligibleEntity : FullAuditedEntity<long>
    {
        public string Name { get; set; }
       
        public Category Category { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        [ForeignKey("Area")]
        public long? AreaId { get; set; }
        public Area Area { get; set; }

        [ForeignKey("ActivityType")]
        public long? ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }

        [ForeignKey("Activity")]
        public long? ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
