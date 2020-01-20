using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HypertropeCore.Context;
using HypertropeCore.Contracts.V1.Request;
using HypertropeCore.Contracts.V1.Response;
using HypertropeCore.Models;
using HypertropeCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;
        
        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost(ApiRoutes.Workouts.Create)]
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutCreateRequest request)
        {
            var created = await _workoutService.AddWorkout(request);
            if (!created)
            {
                return StatusCode(500);
            }

            return StatusCode(201);
        }

        [HttpGet(ApiRoutes.Workouts.ShowAll)]
        public async Task<IActionResult> ShowWorkouts()
        {
            var allResponseWorkouts = await _workoutService.FetchAllWorkouts();

            return new JsonResult(new Response<List<WorkoutResponse>>(allResponseWorkouts));
        }
        
        [HttpGet(ApiRoutes.Workouts.Count)]
        public async Task<IActionResult> Count()
        {
            return new JsonResult(new {WorkoutCount = await _workoutService.GetWorkoutCount()});
        }
        
        [HttpGet(ApiRoutes.Workouts.ListByExercise)]
        public async Task<IActionResult> ListByExercise()
        {
            var groupedResponse = await _workoutService.FetchWorkoutsByExercise();
            
            return new JsonResult(new Response<GroupedByExerciseWorkoutResponse>(groupedResponse));
        }

        [HttpGet(ApiRoutes.Workouts.ListByDate)]
        public async Task<IActionResult> ListByDate()
        {
            var allResponseWorkouts = await _workoutService.FetchAllWorkoutsDateSorted();

            return new JsonResult(new Response<List<WorkoutResponse>>(allResponseWorkouts));
        }
        
        [HttpGet(ApiRoutes.Workouts.ListPb)]
        public IActionResult ListPb()
        {
           throw new NotImplementedException();
        }
    }
}