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
            builder.HasData(
                new Quote
                {
                    QuoteId = Guid.Parse("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                    CreatedAt = DateTime.Now,
                    Body =
                        "I fear not the man who has practiced 10,000 kicks once, but I fear the man who has practiced one kick 10,000 times.",
                    Author = "Bruce Lee",
                    QuoteCategoryId = Guid.Parse("a00701ef-e319-4912-a10c-a2dfe5f53711")
                },
                new Quote
                {
                    QuoteId = Guid.Parse("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                    CreatedAt = DateTime.Now,
                    Body = "The successful warrior is the average man, with laser-like focus",
                    Author = "Bruce Lee",
                    QuoteCategoryId = Guid.Parse("a00701ef-e319-4912-a10c-a2dfe5f53711")
                });
        }
    }
}