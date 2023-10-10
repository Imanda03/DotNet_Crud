using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> connection) : base(connection) { }

        public EmployeeContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().ToTable("Employees");

            modelBuilder.Entity<Employees>().HasKey(e => e.EmployeeId);
        }
        public DbSet<Employees> Employees { get; set; }
    }
}
