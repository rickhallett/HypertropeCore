using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HypertropeCore.Context;
using HypertropeCore.DataTransferObjects;
using HypertropeCore.DataTransferObjects.Request;
using HypertropeCore.DataTransferObjects.Response;
using HypertropeCore.Extensions;
using HypertropeCore.Models;
using HypertropeCore.Repository;
using HypertropeCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    [Authorize]
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
            var created = await _workoutService.AddWorkout(request, HttpContext.GetUserId());
            if (!created)
            {
                return StatusCode(500);
            }

            return StatusCode(201);
        }

        [HttpGet(ApiRoutes.Workouts.ShowAll)]
        public async Task<IActionResult> ShowWorkouts()
        {
            var h = HttpContext.User;
            var allResponseWorkouts = await _workoutService.FetchAllUserWorkouts(HttpContext.GetUserId());

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
            var groupedResponse = await _workoutService.FetchAllUserWorkoutsByExercise(HttpContext.GetUserId());
            
            return new JsonResult(new Response<GroupedByExerciseWorkoutResponse>(groupedResponse));
        }

        [HttpGet(ApiRoutes.Workouts.ListByDate)]
        public async Task<IActionResult> ListByDate()
        {
            var allResponseWorkouts = await _workoutService.FetchAllUserWorkoutsDateSorted(HttpContext.GetUserId());

            return new JsonResult(new Response<List<WorkoutResponse>>(allResponseWorkouts));
        }
        
        [HttpGet(ApiRoutes.Workouts.ListPb)]
        public IActionResult ListPb()
        {
           throw new NotImplementedException();
        }
    }
}