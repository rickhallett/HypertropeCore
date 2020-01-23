using System;
using System.Linq;
using System.Threading.Tasks;
using HypertropeCore.Context;
using HypertropeCore.Contracts.V1.Request;
using HypertropeCore.Contracts.V1.Response;
using HypertropeCore.Domain;
using HypertropeCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    [ApiController]
    public class QuoteController : Controller
    {
        private readonly HypertropeCoreContext _context;

        public QuoteController(HypertropeCoreContext context)
        {
            _context = context;
        }

        [HttpPost(ApiRoutes.Quotes.Create)]
        public async Task<IActionResult> CreateQuote([FromBody] CreateQuoteRequest request)
        {
            var newQuote = new Quote
            {
                QuoteId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Author = request.Author,
                Body = request.Body
            };

            await _context.Quotes.AddAsync(newQuote);
            await _context.SaveChangesAsync();

            return Created("created", newQuote);
        }
        
        [HttpGet(ApiRoutes.Quotes.ShowAll)]
        public IActionResult QuoteList()
        {
            var allQuotes = _context.Quotes.ToList();
            return new JsonResult(new {Quotes = allQuotes});
        }
    }
}