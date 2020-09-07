using EmployeesManagement.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace EmployeesManagement.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<EmployeesDbContext>();
            services.AddSingleton<EmployeesManager>();

            services.AddTransient<IUserDialogService, WindowUserDialogService>();
            return services;
        }
    }
}
