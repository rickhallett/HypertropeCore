using System.Collections.Generic;

namespace HypertropeCore.DataTransferObjects.Response
{
    public class GroupedByExerciseWorkoutResponse
    {
        public List<ExerciseGroup> Exercises { get; set; } = new List<ExerciseGroup>();
    }
}