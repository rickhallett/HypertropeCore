namespace HypertropeCore.Repository
{
    public interface IRepositoryManager
    {
        IExerciseRepository Exercise { get; }
        IWorkoutRepository Workout { get; }
        IQuoteRepository Quote { get; }
        IQuoteCategoryRepository QuoteCategory { get; }
        ISetRepository Set { get; }
        IFastingPeriodRepository FastingPeriod { get; }
        IVitalitySnapshotRepository VitalitySnapshot { get; }
        IMeditationLogRepository MeditationLog { get; }
        IUserRepository User { get; }
        int Save();
    }
}