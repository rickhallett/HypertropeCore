using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<MeditationLog> GetAllMeditationLogs(bool trackChanges = false)
        {
           return FindAll(trackChanges)
               .OrderBy(ml => ml.Created)
               .ToList();
        }

        public MeditationLog GetMeditationLog(Guid id, bool trackChanges = false)
        {
            return FindByCondition(m => m.MeditationLogId == id, trackChanges)
                .SingleOrDefault();
        }

        public void CreateMeditationLog(MeditationLog meditationLog)
        {
            Create(meditationLog);
        }
    }
}