using HypertropeCore.Context;

namespace HypertropeCore.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly HypertropeCoreContext _repositoryContext;
        private IExerciseRepository _exerciseRepository;
        private IWorkoutRepository _workoutRepository;
        private IQuoteRepository _quoteRepository;
        private ISetRepository _setRepository;
        private IFastingPeriodRepository _fastingPeriodRepository;
        private IVitalitySnapshotRepository _vitalitySnapshotRepository;
        private IMeditationLogRepository _meditationLogRepository;
        private IUserRepository _userRepository;

        public RepositoryManager(HypertropeCoreContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IExerciseRepository Exercise => _exerciseRepository ??= new ExerciseRepository(_repositoryContext);
        public IWorkoutRepository Workout => _workoutRepository ??= new WorkoutRepository(_repositoryContext);

        public IQuoteRepository Quote => _quoteRepository ??= new QuoteRepository(_repositoryContext);
        public ISetRepository Set => _setRepository ??= new SetRepository(_repositoryContext);

        public IFastingPeriodRepository FastingPeriod =>
            _fastingPeriodRepository ??= new FastingPeriodRepository(_repositoryContext);

        public IVitalitySnapshotRepository VitalitySnapshot =>
            _vitalitySnapshotRepository ??= new VitalitySnapshotRepository(_repositoryContext);

        public IMeditationLogRepository MeditationLog =>
            _meditationLogRepository ??= new MeditationLogRepository(_repositoryContext);

        public IUserRepository User => _userRepository ??= new UserRepository(_repositoryContext);
        public int Save() => _repositoryContext.SaveChanges();
    }
}