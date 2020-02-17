using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public interface IQuoteRepository
    {
        IQueryable<Quote> FindAll(bool trackChanges = false);
        IQueryable<Quote> FindByCondition(Expression<Func<Quote, bool>> expression, bool trackChanges = false);
        void Create(Quote quote);
        void Update(Quote quote);
        void Delete(Quote quote);

        IEnumerable<Quote> GetAllQuotes(bool trackChanges = false);
    }
}