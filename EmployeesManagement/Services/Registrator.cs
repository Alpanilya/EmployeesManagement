using Microsoft.Extensions.DependencyInjection;
namespace EmployeesManagement.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<EmployeesDbContext>();
            services.AddSingleton<EmployeesManager>();

            return services;
        }
    }
}
