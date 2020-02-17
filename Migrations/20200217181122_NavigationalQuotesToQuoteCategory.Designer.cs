﻿// <auto-generated />
using System;
using HypertropeCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HypertropeCore.Migrations
{
    [DbContext(typeof(HypertropeCoreContext))]
    [Migration("20200217181122_NavigationalQuotesToQuoteCategory")]
    partial class NavigationalQuotesToQuoteCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HypertropeCore.Domain.Exercise", b =>
                {
                    b.Property<Guid>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            ExerciseId = new Guid("2e1449dc-b751-4bed-8dd2-4cf3fa186586"),
                            Abbreviation = "sq",
                            Name = "Squat"
                        },
                        new
                        {
                            ExerciseId = new Guid("70aa3e53-9581-4c9d-8502-9cfed90786a3"),
                            Abbreviation = "bp",
                            Name = "Bench Press"
                        },
                        new
                        {
                            ExerciseId = new Guid("70f3fa12-cdac-4efb-8d35-773c511e5df0"),
                            Abbreviation = "mp",
                            Name = "Military Press"
                        },
                        new
                        {
                            ExerciseId = new Guid("32e7c0e8-a5f2-4fc8-bdb9-32ad8f5c70ac"),
                            Abbreviation = "dl",
                            Name = "Deadlift"
                        },
                        new
                        {
                            ExerciseId = new Guid("e85442ca-6143-4a87-a87d-62d7c962308e"),
                            Abbreviation = "lr",
                            Name = "Leg Raise"
                        },
                        new
                        {
                            ExerciseId = new Guid("a8cde4b5-343c-4881-bee3-1db3067e7feb"),
                            Abbreviation = "ur",
                            Name = "Upright Row"
                        },
                        new
                        {
                            ExerciseId = new Guid("3b847791-2042-49c1-bec7-3fd99efef349"),
                            Abbreviation = "pu",
                            Name = "Pull up"
                        },
                        new
                        {
                            ExerciseId = new Guid("6a62969b-2790-4d74-b1d5-2cb75bd59d3f"),
                            Abbreviation = "cu",
                            Name = "Chin Up"
                        });
                });

            modelBuilder.Entity("HypertropeCore.Domain.FastingPeriod", b =>
                {
                    b.Property<Guid>("FastingPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FastingPeriodId")
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<DateTime>("Finished")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Started")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("FastingPeriodId");

                    b.ToTable("FastingPeriods");
                });

            modelBuilder.Entity("HypertropeCore.Domain.MeditationLog", b =>
                {
                    b.Property<Guid>("MeditationLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MeditationLogId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Silence")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Willingness")
                        .HasColumnType("integer");

                    b.HasKey("MeditationLogId");

                    b.ToTable("MeditationLogs");
                });

            modelBuilder.Entity("HypertropeCore.Domain.Quote", b =>
                {
                    b.Property<Guid>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("QuoteCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("QuoteId");

                    b.HasIndex("QuoteCategoryId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            QuoteId = new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                            Author = "Bruce Lee",
                            Body = "I fear not the man who has practiced 10,000 kicks once, but I fear the man who has practiced one kick 10,000 times.",
                            CreatedAt = new DateTime(2020, 2, 17, 18, 11, 19, 980, DateTimeKind.Local).AddTicks(7480),
                            QuoteCategoryId = new Guid("a00701ef-e319-4912-a10c-a2dfe5f53711")
                        },
                        new
                        {
                            QuoteId = new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                            Author = "Bruce Lee",
                            Body = "The successful warrior is the average man, with laser-like focus",
                            CreatedAt = new DateTime(2020, 2, 17, 18, 11, 19, 981, DateTimeKind.Local).AddTicks(160),
                            QuoteCategoryId = new Guid("a00701ef-e319-4912-a10c-a2dfe5f53711")
                        });
                });

            modelBuilder.Entity("HypertropeCore.Domain.QuoteCategory", b =>
                {
                    b.Property<Guid>("QuoteCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("QuoteCategoryId");

                    b.ToTable("QuoteCategories");
                });

            modelBuilder.Entity("HypertropeCore.Domain.Set", b =>
                {
                    b.Property<Guid>("SetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Exercise")
                        .HasColumnType("text");

                    b.Property<double>("OneRm")
                        .HasColumnType("double precision");

                    b.Property<int>("Reps")
                        .HasColumnType("integer");

                    b.Property<int>("Volume")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid");

                    b.HasKey("SetId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("HypertropeCore.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HypertropeCore.Domain.VitalitySnapshot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VitalitySnapshotId")
                        .HasColumnType("uuid");

                    b.Property<int>("Anxiety")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Energy")
                        .HasColumnType("integer");

                    b.Property<bool>("Fasted")
                        .HasColumnType("boolean");

                    b.Property<int>("Focus")
                        .HasColumnType("integer");

                    b.Property<int>("Mood")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("VitalitySnapshots");
                });

            modelBuilder.Entity("HypertropeCore.Domain.Workout", b =>
                {
                    b.Property<Guid>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("AverageOneRm")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("TotalVolume")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("WorkoutId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "35815486-38d6-4af0-927c-5bcf1f3439c5",
                            ConcurrencyStamp = "03c96baa-57b6-4f7d-bdf3-a35bbdf3dba5",
                            Name = "Superadmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "083f87b8-3742-400b-bcfd-78e35555c1e1",
                            ConcurrencyStamp = "e24ac6e7-9e51-4404-b5b6-a2f8bc73c2c7",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HypertropeCore.Domain.Quote", b =>
                {
                    b.HasOne("HypertropeCore.Domain.QuoteCategory", "QuoteCategory")
                        .WithMany("Quotes")
                        .HasForeignKey("QuoteCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HypertropeCore.Domain.Set", b =>
                {
                    b.HasOne("HypertropeCore.Domain.Workout", null)
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HypertropeCore.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HypertropeCore.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HypertropeCore.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HypertropeCore.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
