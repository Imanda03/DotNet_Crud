using fortest.Controllers.Module;
using fortest.Controllers.StudentModule;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace API.Controllers.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
                        .ToTable("Employee");

            modelBuilder.Entity<Employees>().HasKey(e => e.EmpId);
            modelBuilder.Entity<Employees>().HasMany(e => e.Students).WithOne(e => e.Employees).HasForeignKey(e => e.StuId).OnDelete(DeleteBehavior.Cascade); ;
            modelBuilder.Entity<Students>().ToTable("Student");
            modelBuilder.Entity<Students>().HasKey(e => e.StuId);


        }
        public DbSet<Employees> Employees { get; set; }


        public DbSet<Students> Students { get; set; }
    }
}
