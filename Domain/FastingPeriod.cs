using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypertropeCore.Domain
{
    public class FastingPeriod
    {
        [Key]
        [Column("FastingPeriodId")]
        public Guid FastingPeriodId { get; set; }
        
        public DateTime Started { get; set; }
        
        public DateTime Finished { get; set; }
        
        public TimeSpan Duration { get; set; }
    }
}