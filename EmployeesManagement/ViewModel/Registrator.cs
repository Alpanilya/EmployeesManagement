using Microsoft.Extensions.DependencyInjection;

namespace EmployeesManagement.ViewModel
{
    internal static class Registrator
    {
        public static IServiceCollection RegistratorViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

            return services;
        }
    }
}
