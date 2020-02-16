using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HypertropeCore.Context;
using HypertropeCore.DataTransferObjects;
using HypertropeCore.DataTransferObjects.Request;
using HypertropeCore.DataTransferObjects.Response;
using HypertropeCore.Domain;
using HypertropeCore.Models;
using HypertropeCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace HypertropeCore.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepositoryManager _repositoryManager;
        
        public WorkoutService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Task<int> GetWorkoutCount()
        {
            return _repositoryManager.Workout.FindAll().CountAsync();
        }

        public async Task<bool> UserOwnsWorkout(Guid workoutId, string userId)
        {
            var workout = _repositoryManager.Workout.FindByCondition(w => w.WorkoutId == workoutId).SingleOrDefault();

            if (workout == null)
            {
                return false;
            }

            if (userId != workout.UserId.ToString())
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AddWorkout(WorkoutCreateRequest workoutCreateRequest, string userId)
        {
            var workout = ConstructNewWorkout(workoutCreateRequest);
            workout.UserId = Guid.Parse(userId);
            
            _repositoryManager.Workout.Create(workout);
            var updated = _repositoryManager.Save();

            return updated > 0;
        }

        public async Task<List<WorkoutResponse>> FetchAllUserWorkouts(string userId)
        {
            return await HydrateWorkoutsWithSets(userId);
        }

        public async Task<List<WorkoutResponse>> FetchAllUserWorkoutsDateSorted(string userId)
        {
            var allResponseWorkouts = await HydrateWorkoutsWithSets(userId);
            
            allResponseWorkouts.Sort(delegate(WorkoutResponse a, WorkoutResponse b)
            {
                if (a.Created > b.Created) return 1;
                else if (a.Created < b.Created) return -1;
                else return 0;
            });

            return allResponseWorkouts;
        }

        public async Task<GroupedByExerciseWorkoutResponse> FetchAllUserWorkoutsByExercise(string userId)
        {
            var allResponseWorkouts = await HydrateWorkoutsWithSets(userId);
            var availableExercises = _repositoryManager.Exercise.FindAll();
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
                Notes = request.Notes
            };

            workout.Sets = request.Sets.Select(rs => new Set
            {
                WorkoutId = workout.WorkoutId,
                Created = DateTime.Now,
                SetId = Guid.NewGuid(),
                Exercise = rs.Exercise,
                Reps = rs.Reps,
                Weight = rs.Weight,
                Volume = rs.Reps * rs.Weight,
                OneRm = rs.Weight / (1.0278 - 0.0278 * rs.Reps)
            }).ToList();

            workout.TotalVolume = workout.Sets.Select(s => s.Volume).Sum();
            workout.AverageOneRm = workout.Sets.Select(s => s.OneRm).Sum() / workout.Sets.Count;

            return workout;
        }
        
        private async Task<List<WorkoutResponse>> HydrateWorkoutsWithSets(string userId)
        {
            var allDbWorkouts = await _repositoryManager.Workout.FindByCondition(w => w.UserId.ToString() == userId).ToListAsync();
            var allResponseWorkouts = new List<WorkoutResponse>();

            foreach (var dbwo in allDbWorkouts)
            {
                var workoutResponse = new WorkoutResponse
                {
                    WorkoutId = dbwo.WorkoutId,
                    UserId = Guid.Parse(userId),
                    Created = dbwo.Created,
                    AverageOneRm = dbwo.AverageOneRm,
                    TotalVolume = dbwo.TotalVolume,
                    Sets = _repositoryManager.Set.FindByCondition(s => s.WorkoutId == dbwo.WorkoutId)
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
                Created = s.Created
            };
        }
    }
}