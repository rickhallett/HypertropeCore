using HypertropeCore.Context;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(HypertropeCoreContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}