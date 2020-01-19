using System;

namespace HypertropeCore.Contracts.V1.Response
{
    public class SetResponse
    {
        public Guid SetId { get; set; }
        public string Exercise { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
        public int Volume { get; set; }
        public double OneRm { get; set; }
        public DateTime Created { get; set; }
    }
}