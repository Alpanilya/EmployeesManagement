using EmployeesManagement.Command;
using EmployeesManagement.Model;
using EmployeesManagement.Services;
using EmployeesManagement.Services.Interfaces;
using EmployeesManagement.ViewModel.Base;
using System.Windows.Input;

namespace EmployeesManagement.ViewModel
{
    internal class MainWindowViewModel: BaseViewModel
    {
        #region Поля
        private readonly EmployeesManager _EmployeesManager;
        private readonly IUserDialogService _UserDialog;

        #endregion

        #region Свойства

        private string _Title = "Employee Management";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion


        #region Команды

        #region Редактирование работника
        private ICommand _EditEmployeeCommand;
        public ICommand EditEmployeeCommand => _EditEmployeeCommand ??= new LambdaCommand(OnEditEmployeeCommandExecuted, CanEditEmployeeCommandExecute);
        private bool CanEditEmployeeCommandExecute(object p) => p is Employee;
        private void OnEditEmployeeCommandExecuted(object p)
        {

        }
        #endregion

        #region Создание работника
        private ICommand _CreateEmployeeCommand;
        public ICommand CreateEmployeeCommand => _CreateEmployeeCommand ??= new LambdaCommand(OnCreateEmployeeCommandExecuted, CanCreateEmployeeCommandExecute);
        private bool CanCreateEmployeeCommandExecute(object p) => p is Departament;
        private void OnCreateEmployeeCommandExecuted(object p)
        {

        }
        #endregion

        #region Удаление работника
        private ICommand _RemoveEmployeeCommand;
        public ICommand RemoveEmployeeCommand => _RemoveEmployeeCommand ??= new LambdaCommand(OnRemoveEmployeeCommandExecuted, CanRemoveEmployeeCommandExecute);
        private bool CanRemoveEmployeeCommandExecute(object p) => p is Employee;
        private void OnRemoveEmployeeCommandExecuted(object p)
        {

        }
        #endregion

        #region Создание подразделения
        private ICommand _CreateDepartamentCommand;
        public ICommand CreateDepartamentCommand => _CreateDepartamentCommand ??= new LambdaCommand(OnCreateDepartamentCommandExecuted, CanCreateDepartamentCommandExecute);
        private bool CanCreateDepartamentCommandExecute(object p) => true;
        private void OnCreateDepartamentCommandExecuted(object p)
        {
            var departament = new Departament();
            if(_UserDialog.Create(departament))
            {
                _EmployeesManager.Add(departament);
                _UserDialog.ShowInfo("Подразделение успешно создано", "Добавление подразделения");
                return;
            }
            if (_UserDialog.Confirm("Не удалось создать подразделение. \n Повторить?", "Добавление подразделения"))
                OnCreateDepartamentCommandExecuted(p);
        }
        #endregion

        #region Удаление подразделения
        private ICommand _RemoveDepartamentCommand;
        public ICommand RemoveDepartamentCommand => _RemoveDepartamentCommand ??= new LambdaCommand(OnRemoveDepartamentCommandExecuted, CanRemoveDepartamentCommandExecute);
        private bool CanRemoveDepartamentCommandExecute(object p) => p is Departament;
        private void OnRemoveDepartamentCommandExecuted(object p)
        {
           
        }
        #endregion

        #endregion

        public MainWindowViewModel(EmployeesManager EmployeesManager, IUserDialogService UserDialogService)
        {
            _EmployeesManager = EmployeesManager;
            _UserDialog = UserDialogService;
        }
    }
}
