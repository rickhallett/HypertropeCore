﻿// <auto-generated />
using System;
using HypertropeCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HypertropeCore.Migrations
{
    [DbContext(typeof(HypertropeCoreContext))]
    [Migration("20200118135040_ChangeExerciseTypeToString")]
    partial class ChangeExerciseTypeToString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HypertropeCore.Models.Metric", b =>
                {
                    b.Property<Guid>("MetricId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OneRm")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("MetricId");

                    b.ToTable("Metrics");
                });

            modelBuilder.Entity("HypertropeCore.Models.Set", b =>
                {
                    b.Property<Guid>("SetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Exercise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<Guid?>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SetId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("HypertropeCore.Models.Workout", b =>
                {
                    b.Property<Guid>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.HasKey("WorkoutId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("HypertropeCore.Models.Set", b =>
                {
                    b.HasOne("HypertropeCore.Models.Workout", null)
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutId");
                });
#pragma warning restore 612, 618
        }
    }
}
