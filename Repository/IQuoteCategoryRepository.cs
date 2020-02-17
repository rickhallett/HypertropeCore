using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public interface IQuoteCategoryRepository
    {
        IQueryable<QuoteCategory> FindAll(bool trackChanges = false);
        IQueryable<QuoteCategory> FindByCondition(Expression<Func<QuoteCategory, bool>> expression, bool trackChanges = false);
        void Create(QuoteCategory quoteCategory);
        void Update(QuoteCategory quoteCategory);
        void Delete(QuoteCategory quoteCategory);

        QuoteCategory GetQuoteCategoryByName(string name, bool trackChanges = false);
        QuoteCategory GetQuoteCategoryById(Guid id, bool trackChanges = false);
        IEnumerable<QuoteCategory> GetQuoteCategories(bool trackChanges = false);
    }
}