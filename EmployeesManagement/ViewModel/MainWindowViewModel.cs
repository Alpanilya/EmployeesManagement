using EmployeesManagement.ViewModel.Base;

namespace EmployeesManagement.ViewModel
{
    internal class MainWindowViewModel: BaseViewModel
    {
        private string _Title = "Employee Management";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
