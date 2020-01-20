using HypertropeCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HypertropeCore.Context
{
    public class HypertropeCoreContext : IdentityDbContext<User>
    {
        public DbSet<Set> Sets { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }    
        public DbSet<Quote> Quotes { get; set; }   

        public HypertropeCoreContext(DbContextOptions<HypertropeCoreContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new QuoteConfiguration());
        }
    }
}