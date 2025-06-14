using Microsoft.EntityFrameworkCore;
using VIPClinicAPI.Models;

namespace VIPClinicAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => new { c.FullName, c.FileNumber, c.VisitDate })
                .IsUnique();
        }
    }
}
