using System;
using HypertropeCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HypertropeCore.Models
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasData(new Quote
                {
                    QuoteId = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Body =
                        "I fear not the man who has practiced 10,000 kicks once, but I fear the man who has practiced one kick 10,000 times.",
                    Author = "Bruce Lee"
                },
                new Quote
                {
                    QuoteId = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Body = "The successful warrior is the average man, with laser-like focus",
                    Author = "Bruce Lee"
                });
        }
    }
}