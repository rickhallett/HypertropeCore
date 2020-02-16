using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contract;
using HypertropeCore.DataTransferObjects.Request;
using HypertropeCore.DataTransferObjects.Response;
using HypertropeCore.Domain;
using HypertropeCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    [ApiController]
    public class MeditationLogController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public MeditationLogController(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.MeditationLog.ShowAll)]
        public IActionResult GetMeditationLogs()
        {
            try
            {
                var meditationLogs = _repositoryManager.MeditationLog.GetAllMeditationLogs();

                // var meditationLogsDto = meditationLogs.Select(m => new MeditationLogResponseDto
                // {
                //     MeditationLogId = m.MeditationLogId,
                //     Created = m.Created,
                //     Notes = m.Notes,
                //     Silence = m.Silence,
                //     Willingness = m.Willingness
                // }).ToList();

                var meditationLogsDto = _mapper.Map<IEnumerable<MeditationLogResponseDto>>(meditationLogs);

                return Ok(meditationLogsDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetMeditationLogs)} action. Exception: {e.Message}");
                _logger.LogError(e.StackTrace);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(ApiRoutes.MeditationLog.Create)]
        public IActionResult CreateMeditationLog([FromBody] CreateMeditationLogDto request)
        {
            try
            {
                _repositoryManager.MeditationLog.CreateMeditationLog(_mapper.Map<MeditationLog>(request));
                _repositoryManager.Save();

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong with the {nameof(CreateMeditationLog)} action. Exception: {e}");
                _logger.LogError(e.StackTrace);

                return StatusCode(500, "Internal server error");
            }
        }
    }
}