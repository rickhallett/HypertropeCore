using System;
using System.Linq;
using System.Linq.Expressions;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public interface IExerciseRepository
    {
        IQueryable<Exercise> FindAll(bool trackChanges = false);
        IQueryable<Exercise> FindByCondition(Expression<Func<Exercise, bool>> expression, bool trackChanges = false);
        void Create(Exercise exercise);
        void Update(Exercise exercise);
        void Delete(Exercise exercise);
    }
}