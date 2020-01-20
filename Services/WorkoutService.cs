using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HypertropeCore.Context;
using HypertropeCore.Contracts.V1.Request;
using HypertropeCore.Contracts.V1.Response;
using HypertropeCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HypertropeCore.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly HypertropeCoreContext _context;
        
        public WorkoutService(HypertropeCoreContext context)
        {
            _context = context;
        }

        public Task<int> GetWorkoutCount()
        {
            return _context.Workouts.CountAsync();
        }

        public async Task<bool> AddWorkout(WorkoutCreateRequest workoutCreateRequest)
        {
            var workout = ConstructNewWorkout(workoutCreateRequest);
            
            await _context.Workouts.AddAsync(workout);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<List<WorkoutResponse>> FetchAllWorkouts()
        {
            return await HydrateAllWorkoutsWithSets();
        }

        public async Task<List<WorkoutResponse>> FetchAllWorkoutsDateSorted()
        {
            var allResponseWorkouts = await HydrateAllWorkoutsWithSets();
            
            allResponseWorkouts.Sort(delegate(WorkoutResponse a, WorkoutResponse b)
            {
                if (a.Created > b.Created) return 1;
                else if (a.Created < b.Created) return -1;
                else return 0;
            });

            return allResponseWorkouts;
        }

        public async Task<GroupedByExerciseWorkoutResponse> FetchWorkoutsByExercise()
        {
            var allResponseWorkouts = await HydrateAllWorkoutsWithSets();

            var availableExercises = _context.Exercises.ToList();
            
            var groupedResponse = new GroupedByExerciseWorkoutResponse();

            foreach (var exercise in availableExercises)
            {
                groupedResponse.Exercises.Add(new ExerciseGroup
                {
                    Name = exercise.Name
                });
            }

            foreach (var workout in allResponseWorkouts)
            {
                foreach (var set in workout.Sets)
                {
                    var name = set.Exercise.ToLowerInvariant();
                    var group = groupedResponse.Exercises.Find(eg => eg.Name.ToLowerInvariant() == name);
                    group?.Sets.Add(set);
                }
            }

            foreach (var exercise in groupedResponse.Exercises)
            {
                exercise.Sets.Sort(delegate(SetResponse a, SetResponse b)
                {
                    if (a.Created > b.Created) return 1;
                    else if (a.Created < b.Created) return -1;
                    else return 0;
                });
            }

            return groupedResponse;
        }
        
        private Workout ConstructNewWorkout(WorkoutCreateRequest request)
        {
            var workout =  new Workout
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

            return workout;
        }
        
        private async Task<List<WorkoutResponse>> HydrateAllWorkoutsWithSets()
        {
            var allDbWorkouts = await _context.Workouts.ToListAsync();
            var allResponseWorkouts = new List<WorkoutResponse>();

            foreach (var dbwo in allDbWorkouts)
            {
                var workoutResponse = new WorkoutResponse
                {
                    WorkoutId = dbwo.WorkoutId,
                    Created = dbwo.Created,
                    AverageOneRm = dbwo.AverageOneRm,
                    TotalVolume = dbwo.TotalVolume,
                    Sets =  _context.Sets
                        .Where(s => s.Workout.WorkoutId == dbwo.WorkoutId)
                        .Select(s => ConstructSetResponse(s))
                        .ToList(),
                    Notes = dbwo.Notes
                };
                
                allResponseWorkouts.Add(workoutResponse);
            }

            return allResponseWorkouts;
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
                Weight = s.Weight,
                Created = s.Workout.Created
            };
        }
    }
}