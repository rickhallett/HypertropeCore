using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HypertropeCore.Context;
using HypertropeCore.Contracts.V1.Request;
using HypertropeCore.Contracts.V1.Response;
using HypertropeCore.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutCreateRequest request)
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
                }).ToList(),
                Notes = request.Notes
            };

            workout.TotalVolume = workout.Sets.Select(s => s.Volume).Sum();
            workout.AverageOneRm = workout.Sets.Select(s => s.OneRm).Sum() / workout.Sets.Count;
            workout.RickFactor = (double)workout.TotalVolume / workout.Sets.Count / workout.Sets.Select(s => s.Reps).Sum();

            await _context.Workouts.AddAsync(workout);
            var updated = await _context.SaveChangesAsync();
            
            
            return new JsonResult(new Response<WorkoutCreatedResponse>(new WorkoutCreatedResponse{WorkoutId = workout.WorkoutId}));
        }

        [HttpGet(ApiRoutes.Workouts.ShowAll)]
        public IActionResult ShowWorkouts()
        {
            var allDbWorkouts = _context.Workouts.ToList();
            var allResponseWorkouts = new List<WorkoutResponse>();

            foreach (var dbwo in allDbWorkouts)
            {
                var workoutResponse = new WorkoutResponse
                {
                    WorkoutId = dbwo.WorkoutId,
                    Created = dbwo.Created,
                    AverageOneRm = dbwo.AverageOneRm,
                    TotalVolume = dbwo.TotalVolume,
                    RickFactor = dbwo.RickFactor,
                    Sets =  _context.Sets
                        .Where(s => s.Workout.WorkoutId == dbwo.WorkoutId)
                        .Select(s => ConstructSetResponse(s))
                        .ToList(),
                    Notes = dbwo.Notes
                };
                
                allResponseWorkouts.Add(workoutResponse);
            }
            
            return new JsonResult(new Response<List<WorkoutResponse>>(allResponseWorkouts));
        }

        private static SetResponse ConstructSetResponse(Set s)
        {
            return new SetResponse
            {
                Exercise = s.Exercise,
                OneRm = s.OneRm,
                Reps = s.Reps,
                SetId = s.SetId,
                Volume = s.Volume,
                Weight = s.Weight
            };
        }
    }
}