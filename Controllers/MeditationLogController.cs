using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contract;
using HypertropeCore.DataTransferObjects.Request;
using HypertropeCore.DataTransferObjects.Response;
using HypertropeCore.Domain;
using HypertropeCore.Extensions;
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
            var meditationLogs = _repositoryManager.MeditationLog.GetAllMeditationLogs();

            var meditationLogsDto = _mapper.Map<IEnumerable<MeditationLogResponseDto>>(meditationLogs);

            return Ok(meditationLogsDto);
        }

        [HttpPost(ApiRoutes.MeditationLog.Create)]
        public IActionResult CreateMeditationLog([FromBody] CreateMeditationLogDto request)
        {
            var newMeditationLog = _mapper.Map<MeditationLog>(request);
            newMeditationLog.UserId = Guid.Parse(HttpContext.GetUserId());

            _repositoryManager.MeditationLog.CreateMeditationLog(newMeditationLog);
            _repositoryManager.Save();

            return Ok();
        }
    }
}