using System;
using System.Collections.Generic;
using System.Linq;
using HypertropeCore.Context;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public class QuoteCategoryRepository : RepositoryBase<QuoteCategory>, IQuoteCategoryRepository
    {
        public QuoteCategoryRepository(HypertropeCoreContext repositoryContext) : base(repositoryContext)
        {
        }

        public QuoteCategory GetQuoteCategoryByName(string name, bool trackChanges = false)
        {
            return FindByCondition(qc => qc.Name == name, trackChanges)
                .SingleOrDefault();
        }

        public QuoteCategory GetQuoteCategoryById(Guid id, bool trackChanges = false)
        {
            return FindByCondition(qc => qc.QuoteCategoryId == id, trackChanges)
                .SingleOrDefault();
        }

        public IEnumerable<QuoteCategory> GetQuoteCategories(bool trackChanges = false)
        {
            return FindAll(trackChanges)
                .ToList();
        }
    }
}