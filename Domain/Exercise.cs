using System;

namespace HypertropeCore.Domain
{
    public class Exercise
    {
        public Guid ExerciseId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}