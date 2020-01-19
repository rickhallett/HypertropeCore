using System.Collections.Generic;

namespace HypertropeCore.Contracts.V1.Response
{
    public class GroupedByExerciseWorkoutResponse
    {
        public List<ExerciseGroup> Exercises { get; set; } = new List<ExerciseGroup>();
    }
}