using HypertropeCore.Context;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public class QuoteRepository : RepositoryBase<Quote>, IQuoteRepository
    {
        public QuoteRepository(HypertropeCoreContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}