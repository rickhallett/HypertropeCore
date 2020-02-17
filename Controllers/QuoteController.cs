using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contract;
using HypertropeCore.Context;
using HypertropeCore.DataTransferObjects;
using HypertropeCore.DataTransferObjects.Request;
using HypertropeCore.Domain;
using HypertropeCore.Models;
using HypertropeCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    [ApiController]
    public class QuoteController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public QuoteController(ILoggerManager logger, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.Quotes.Create)]
        public async Task<IActionResult> CreateQuote([FromBody] CreateQuoteRequestDto requestDto)
        {
            var newQuoteCategory = new QuoteCategory();
            var categoryExists =
                _repositoryManager.QuoteCategory.GetQuoteCategoryByName(requestDto.CategoryName.ToLowerInvariant());
            
            if (categoryExists == null)
            {
                newQuoteCategory.Name = requestDto.CategoryName;
                newQuoteCategory.QuoteCategoryId = Guid.NewGuid();

                _repositoryManager.QuoteCategory.Create(newQuoteCategory);
            }

            if (categoryExists != null)
            {
                newQuoteCategory.Name = categoryExists.Name;
                newQuoteCategory.QuoteCategoryId = categoryExists.QuoteCategoryId;
            }
            
            var newQuote = new Quote
            {
                QuoteId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Author = requestDto.Author,
                Body = requestDto.Body,
                QuoteCategoryId = newQuoteCategory.QuoteCategoryId
            };

            _repositoryManager.Quote.Create(newQuote);
            _repositoryManager.Save();
            
            //TODO: make a quoteDto to prevent JSON object cycle in newQuotes.Quotes navigational property

            return Created("created", newQuote);
        }
        
        [HttpGet(ApiRoutes.Quotes.ShowAll)]
        public IActionResult QuoteList()
        {
            var allQuotes = _repositoryManager.Quote.GetAllQuotes();
            return new JsonResult(new {Quotes = allQuotes});
        }
    }
}