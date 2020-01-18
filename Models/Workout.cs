using System;
using System.Collections.Generic;

namespace HypertropeCore.Models
{
    public class Workout
    {
        public Guid WorkoutId { get; set; }
        public DateTime Created { get; set; }
        public List<Set> Sets { get; set; }
        public int TotalVolume { get; set; }
        public double AverageOneRm { get; set; }
        
        // IndexVal == 'work per set per rep'
        public int IndexVal { get; set; }
    }
}