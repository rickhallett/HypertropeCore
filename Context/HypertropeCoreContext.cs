using HypertropeCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HypertropeCore.Context
{
    public class HypertropeCoreContext : DbContext
    {
        public DbSet<Set> Sets { get; set; }
        public DbSet<Metric> Metrics { get; set; }

        public HypertropeCoreContext(DbContextOptions<HypertropeCoreContext> options) : base(options)
        {
            
        }
    }
}