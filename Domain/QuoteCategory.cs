using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HypertropeCore.Domain
{
    public class QuoteCategory
    {
        [Key]
        [Required]
        public Guid QuoteCategoryId { get; set; }
        
        public string Name { get; set; }
        
        public IEnumerable<Quote> Quotes { get; set; }
    }
}