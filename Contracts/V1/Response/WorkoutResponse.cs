using System;
using System.Collections.Generic;
using HypertropeCore.Models;

namespace HypertropeCore.Contracts.V1.Response
{
    public class WorkoutResponse
    {
        public Guid WorkoutId { get; set; }
        public DateTime Created { get; set; }
        public List<SetResponse> Sets { get; set; }
        public int TotalVolume { get; set; }
        public double AverageOneRm { get; set; }
        public string Notes { get; set; }
    }
}