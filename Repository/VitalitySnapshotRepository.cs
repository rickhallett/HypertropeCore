using HypertropeCore.Context;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public class VitalitySnapshotRepository : RepositoryBase<VitalitySnapshot>, IVitalitySnapshotRepository
    {
        public VitalitySnapshotRepository(HypertropeCoreContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}