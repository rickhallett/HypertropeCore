using System.Collections.Generic;
using System.Threading.Tasks;
using HypertropeCore.Contracts.V1.Request;
using HypertropeCore.Contracts.V1.Response;

namespace HypertropeCore.Services
{
    public interface IWorkoutService
    {
        Task<int> GetWorkoutCount();
        
        Task<bool> AddWorkout(WorkoutCreateRequest workoutCreateRequest);

        Task<List<WorkoutResponse>> FetchAllWorkouts();

        Task<List<WorkoutResponse>> FetchAllWorkoutsDateSorted();

        Task<GroupedByExerciseWorkoutResponse> FetchWorkoutsByExercise();
    }
}