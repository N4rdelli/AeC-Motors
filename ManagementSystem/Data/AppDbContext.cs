using Microsoft.EntityFrameworkCore;
using ManagementSystem.Models;

namespace ManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ManagementSystem.Models.Yard> Yard { get; set; } = default!;
        public DbSet<ManagementSystem.Models.Vehicle> Vehicle { get; set; } = default!;
        public DbSet<ManagementSystem.Models.Costumer> Costumer { get; set; } = default!;
        public DbSet<ManagementSystem.Models.Rental> Rental { get; set; } = default!;
    }
}
