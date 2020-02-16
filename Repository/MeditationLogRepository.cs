using HypertropeCore.Context;
using HypertropeCore.Domain;
using Microsoft.AspNetCore.Authentication;

namespace HypertropeCore.Repository
{
    public class MeditationLogRepository : RepositoryBase<MeditationLog>, IMeditationLogRepository
    {
        public MeditationLogRepository(HypertropeCoreContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}