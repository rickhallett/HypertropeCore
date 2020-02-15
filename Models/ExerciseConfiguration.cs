using System;
using HypertropeCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HypertropeCore.Models
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(new Exercise
            {
                ExerciseId = Guid.Parse("2e1449dc-b751-4bed-8dd2-4cf3fa186586"),
                Name = "Squat",
                Abbreviation = "sq"
            }, new Exercise
            {
                ExerciseId = Guid.Parse("70aa3e53-9581-4c9d-8502-9cfed90786a3"),
                Name = "Bench Press",
                Abbreviation = "bp"
            }, new Exercise
            {
                ExerciseId = Guid.Parse("70f3fa12-cdac-4efb-8d35-773c511e5df0"),
                Name = "Military Press",
                Abbreviation = "mp"
            }, new Exercise
            {
                ExerciseId = Guid.Parse("32e7c0e8-a5f2-4fc8-bdb9-32ad8f5c70ac"),
                Name = "Deadlift",
                Abbreviation = "dl"
            }, new Exercise
            {
                ExerciseId = Guid.Parse("e85442ca-6143-4a87-a87d-62d7c962308e"),
                Name = "Leg Raise",
                Abbreviation = "lr"
            }, new Exercise
            {
                ExerciseId = Guid.Parse("a8cde4b5-343c-4881-bee3-1db3067e7feb"),
                Name = "Upright Row",
                Abbreviation = "ur"
            }, new Exercise
            {
                ExerciseId = Guid.Parse("3b847791-2042-49c1-bec7-3fd99efef349"),
                Name = "Pull up",
                Abbreviation = "pu"
            }, new Exercise
            {
                ExerciseId = Guid.Parse("6a62969b-2790-4d74-b1d5-2cb75bd59d3f"),
                Name = "Chin Up",
                Abbreviation = "cu"
            });
        }
    }
}