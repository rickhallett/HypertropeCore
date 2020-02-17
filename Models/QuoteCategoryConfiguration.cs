using System;
using HypertropeCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HypertropeCore.Models
{
    public class QuoteCategoryConfiguration : IEntityTypeConfiguration<QuoteCategory>
    {
        public void Configure(EntityTypeBuilder<QuoteCategory> builder)
        {
            builder.HasData(new QuoteCategory
            {
                Name = "Motivational",
                QuoteCategoryId = Guid.Parse("a00701ef-e319-4912-a10c-a2dfe5f53711")
            }, new QuoteCategory
            {
                Name = "Profound",
                QuoteCategoryId = Guid.Parse("c5e344c7-ec21-4a75-bcc8-46ff9c638f42")
            });
        }
    }
}