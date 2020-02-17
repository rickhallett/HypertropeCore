using System;
using System.Collections.Generic;
using AutoMapper;
using Contract;
using HypertropeCore.DataTransferObjects.Request;
using HypertropeCore.DataTransferObjects.Response;
using HypertropeCore.Domain;
using HypertropeCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    [Authorize]
    [ApiController]
    public class QuoteCategoryController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public QuoteCategoryController(ILoggerManager logger, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.QuoteCategories.ShowAll)]
        public IActionResult GetQuoteCategories()
        {
            var quoteCategories = _repositoryManager.QuoteCategory.GetQuoteCategories();
            var quoteCategoriesDto = _mapper.Map<IEnumerable<QuoteCategoryResponseDto>>(quoteCategories);

            return Ok(quoteCategoriesDto);
        }

        [HttpGet(ApiRoutes.QuoteCategories.GetByName)]
        public IActionResult GetQuoteCategoryByName([FromRoute] string name)
        {
            var quoteCategory = _repositoryManager.QuoteCategory.GetQuoteCategoryByName(name);
            if (quoteCategory == null)
            {
                _logger.LogInfo($"QuoteCategory by name {name} does not exist");
                return NotFound();
            }
            
            var quoteCategoryDto = _mapper.Map<QuoteCategoryResponseDto>(quoteCategory);

            return Ok(quoteCategoryDto);
        }

        [HttpPost(ApiRoutes.QuoteCategories.Create)]
        public IActionResult CreateQuoteCategory([FromBody] CreateQuoteCategoryDto requestedCategory)
        {
            var existingCategory = _repositoryManager.QuoteCategory.GetQuoteCategoryByName(requestedCategory.Name.ToLowerInvariant());
            if (existingCategory != null)
            {
                var quoteCategoryDto = _mapper.Map<QuoteCategoryResponseDto>(existingCategory);
                return BadRequest(new
                {
                    Message = "A QuoteCategory with this name already exists",
                    Data = quoteCategoryDto
                });
            }
            
            var newQuoteCategory = _mapper.Map<QuoteCategory>(requestedCategory);
            _repositoryManager.QuoteCategory.Create(newQuoteCategory);
            _repositoryManager.Save();
            
            var createdQuoteCategoryDto = _mapper.Map<QuoteCategoryResponseDto>(newQuoteCategory);

            return Created("QuoteCategory created", createdQuoteCategoryDto);
        }
        
    }
}