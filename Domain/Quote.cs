using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypertropeCore.Domain
{
    public class Quote
    {
        public Guid QuoteId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        
        [ForeignKey(nameof(Domain.Quote))]
        public Guid QuoteCategoryId { get; set; }
        public QuoteCategory QuoteCategory { get; set; }
    }
}