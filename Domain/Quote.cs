﻿using System;

namespace HypertropeCore.Domain
{
    public class Quote
    {
        public Guid QuoteId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
    }
}