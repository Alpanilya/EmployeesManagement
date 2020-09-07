using Microsoft.Extensions.DependencyInjection;

namespace EmployeesManagement.ViewModel
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
