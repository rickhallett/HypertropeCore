using System;

namespace HypertropeCore.Models
{
    public class Set
    {
        public Guid SetId { get; set; }
        public DateTime Created { get; set; }
        public ExerciseType Exercise { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
    }
}