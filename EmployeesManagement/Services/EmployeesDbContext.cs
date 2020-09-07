using EmployeesManagement.Model;
using EmployeesManagement.Services.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeesManagement.Services
{
    internal class EmployeesDbContext: DbContext
    {
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public EmployeesDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host= localhost; Port=5432; Database= EmployeesDb; User Id=postgres;Password=password");
            base.OnConfiguring(optionsBuilder);
        }
        public EmployeesDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<EmployeesDbContext> options = new DbContextOptionsBuilder<EmployeesDbContext>();

            options.UseNpgsql("Host= localhost; Port=5432; Database= EmployeesDb; User Id=postgres;Password=password");

            return new EmployeesDbContext(options.Options);
        }

    }
}
