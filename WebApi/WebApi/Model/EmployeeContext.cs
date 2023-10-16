using Microsoft.EntityFrameworkCore;

namespace WebApi.Model
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options) { 
            
        }
        public DbSet<TbEmployee> TbEmployee { get; set; }
        public DbSet<TbDegination> TbDesignation{ get; set; }
    }
}
