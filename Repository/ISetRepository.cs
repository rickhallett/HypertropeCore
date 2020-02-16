using System;
using System.Linq;
using System.Linq.Expressions;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public interface ISetRepository
    {
        IQueryable<Set> FindAll(bool trackChanges = false);
        IQueryable<Set> FindByCondition(Expression<Func<Set, bool>> expression, bool trackChanges = false);
        void Create(Set set);
        void Update(Set set);
        void Delete(Set set);
    }
}