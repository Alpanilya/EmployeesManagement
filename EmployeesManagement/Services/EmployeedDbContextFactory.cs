using Microsoft.EntityFrameworkCore;


namespace EmployeesManagement.Services
{
    internal class EmployeedDbContextFactory
    {
        private readonly string _connectionString;
        public EmployeedDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public EmployeesDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<EmployeesDbContext> options = new DbContextOptionsBuilder<EmployeesDbContext>();

            options.UseNpgsql(_connectionString);

            return new EmployeesDbContext(options.Options);
        }
    }
}
