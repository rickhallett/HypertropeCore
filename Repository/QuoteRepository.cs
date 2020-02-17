using System;
using System.Collections.Generic;
using System.Linq;
using HypertropeCore.Context;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public class QuoteRepository : RepositoryBase<Quote>, IQuoteRepository
    {
        public QuoteRepository(HypertropeCoreContext repositoryContext) : base(repositoryContext)
        {
        }

        public Quote GetQuoteById(Guid id, bool trackChanges = false)
        {
            return FindByCondition(q => q.QuoteId == id, trackChanges)
                .SingleOrDefault();
        }

        public IEnumerable<Quote> GetQuotesByCategoryId(Guid categoryId, bool trackChanges = false)
        {
            return FindByCondition(q => q.QuoteCategoryId == categoryId, trackChanges)
                .ToList();
        }

        public IEnumerable<Quote> GetAllQuotes(bool trackChanges = false)
        {
            return FindAll(trackChanges)
                .ToList();
        }
        

        public void CreateQuote(Quote newQuote)
        {
            Create(newQuote);
        }
    }
}