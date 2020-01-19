using System;

namespace HypertropeCore.Models
{
    public class Quote
    {
        public Guid QuoteId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
    }
}