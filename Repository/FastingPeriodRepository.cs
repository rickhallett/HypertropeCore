using HypertropeCore.Context;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public class FastingPeriodRepository : RepositoryBase<FastingPeriod>, IFastingPeriodRepository
    {
        public FastingPeriodRepository(HypertropeCoreContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}