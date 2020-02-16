using System;
using System.Linq;
using System.Linq.Expressions;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public interface IWorkoutRepository
    {
        IQueryable<Workout> FindAll(bool trackChanges = false);
        IQueryable<Workout> FindByCondition(Expression<Func<Workout, bool>> expression, bool trackChanges = false);
        void Create(Workout workout);
        void Update(Workout workout);
        void Delete(Workout workout);
    }
}