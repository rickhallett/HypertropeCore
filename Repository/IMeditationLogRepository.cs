using System.Collections.Generic;
using HypertropeCore.Domain;

namespace HypertropeCore.Repository
{
    public interface IMeditationLogRepository
    {
        IEnumerable<MeditationLog> GetAllMeditationLogs(bool trackChanges = false);
        void CreateMeditationLog(MeditationLog meditationLog);
    }
}