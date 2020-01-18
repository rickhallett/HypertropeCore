using HypertropeCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HypertropeCore.Context
{
    public class HypertropeCoreContext : DbContext
    {
        public DbSet<Set> Sets { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public HypertropeCoreContext(DbContextOptions<HypertropeCoreContext> options) : base(options)
        {
            
        }
    }
}