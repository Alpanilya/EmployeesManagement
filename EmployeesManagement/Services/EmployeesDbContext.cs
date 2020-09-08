using EmployeesManagement.Model;
using EmployeesManagement.Services.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagement.Services
{
    internal class EmployeesDbContext: DbContext
    {
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public EmployeesDbContext()
        {
            Database.EnsureCreated();
        }
        public EmployeesDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
