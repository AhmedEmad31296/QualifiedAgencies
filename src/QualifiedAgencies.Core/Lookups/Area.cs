using Abp.Domain.Entities.Auditing;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifiedAgencies.Lookups
{
    [Table("Areas")]
    public class Area : FullAuditedEntity<long>
    {
        public string Name { get; set; }
    }
}
