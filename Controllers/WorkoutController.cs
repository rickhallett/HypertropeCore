using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using HypertropeCore.Context;
using HypertropeCore.Contracts.V1.Request;
using HypertropeCore.Contracts.V1.Response;
using HypertropeCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HypertropeCore.Controllers
{
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly HypertropeCoreContext _context;
        
        public WorkoutController(HypertropeCoreContext context)
        {
            _context = context;
        }

        [HttpPost(ApiRoutes.Workouts.Create)]
        public IActionResult CreateWorkout([FromBody] WorkoutCreateRequest request)
        {
            var workout = new Workout
            {
                WorkoutId = Guid.NewGuid(),
                Created = DateTime.Now,
                Sets = request.Sets.Select(rs => new Set
                {
                    SetId = Guid.NewGuid(),
                    Exercise = rs.Exercise,
                    Reps = rs.Reps,
                    Weight = rs.Weight,
                    Volume = rs.Reps * rs.Weight,
                    OneRm = rs.Weight / (1.0278 - 0.0278 * rs.Reps)
                }).ToList()
            };

            workout.TotalVolume = workout.Sets.Select(s => s.Volume).Sum();
            workout.AverageOneRm = workout.Sets.Select(s => s.OneRm).Sum() / workout.Sets.Count;
            
            return new JsonResult(new {Data = workout});
        }

        [HttpGet(ApiRoutes.Workouts.ShowAll)]
        public IActionResult ShowWorkouts()
        {
            return new JsonResult(new {Route = "ShowWorkouts"});
        }
    }
}