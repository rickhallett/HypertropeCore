using System;

namespace HypertropeCore.Models
{
    public class Metric
    {
        public Guid MetricId { get; set; }
        public int Volume { get; set; }
        public int OneRm { get; set; }
        
        public Set Set { get; set; }
    }
}