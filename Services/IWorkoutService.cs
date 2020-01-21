using System.Collections.Generic;
using System.Threading.Tasks;
using HypertropeCore.Contracts.V1.Request;
using HypertropeCore.Contracts.V1.Response;
using Microsoft.AspNetCore.Http;

namespace HypertropeCore.Services
{
    public interface IWorkoutService
    {
        Task<int> GetWorkoutCount();
        
        Task<bool> AddWorkout(WorkoutCreateRequest workoutCreateRequest, string userId);

        Task<List<WorkoutResponse>> FetchAllUserWorkouts(string userId);

        Task<List<WorkoutResponse>> FetchAllUserWorkoutsDateSorted(string userId);

        Task<GroupedByExerciseWorkoutResponse> FetchAllUserWorkoutsByExercise(string userId);
    }
}