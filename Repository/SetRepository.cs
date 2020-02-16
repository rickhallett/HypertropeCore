using HypertropeCore.Context;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public class SetRepository : RepositoryBase<Set>, ISetRepository
    {
        public SetRepository(HypertropeCoreContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}