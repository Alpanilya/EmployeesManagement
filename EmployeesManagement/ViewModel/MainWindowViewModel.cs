using EmployeesManagement.Command;
using EmployeesManagement.Model;
using EmployeesManagement.Services;
using EmployeesManagement.Services.Interfaces;
using EmployeesManagement.ViewModel.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;

namespace EmployeesManagement.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
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
        private Departament _SelectedDepartament;
        public Departament SelectedDepartament
        {
            get => _SelectedDepartament;
            set
            {
                Set(ref _SelectedDepartament, value);
            }
        }
        private Employee _SelectedEmployee;
        public Employee SelectedEmployee
        {
            get => _SelectedEmployee;
            set =>Set(ref _SelectedEmployee, value);
        }
        public ObservableCollection<Departament> Departaments { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        #endregion


        #region Команды

        #region Редактирование работника
        private ICommand _EditEmployeeCommand;
        public ICommand EditEmployeeCommand => _EditEmployeeCommand ??= new LambdaCommand(OnEditEmployeeCommandExecuted, CanEditEmployeeCommandExecute);
        private bool CanEditEmployeeCommandExecute(object p) => p is Employee;
        private void OnEditEmployeeCommandExecuted(object p)
        {
            var employee = (Employee)p;
            var empls = SelectedDepartament.Employees.FirstOrDefault(e => e.Id == employee.Id);
            var eplindex = SelectedDepartament.Employees.IndexOf(empls);

            var emplcol = Employees.FirstOrDefault(e => e.Id == employee.Id);
            var emplindexcol = Employees.IndexOf(emplcol);

            if (_UserDialog.Edit((Employee)p))
            {
                var dep = Departaments.FirstOrDefault(d => d.Id == SelectedDepartament.Id);
                var depindex = Departaments.IndexOf(dep);
                Employees[emplindexcol] = (Employee)p;
                Departaments[depindex].Employees[eplindex] = (Employee)p;
                _UserDialog.ShowInfo("Работник успешно отредактирован", "Редактирование работника");
                return;
            }
            _UserDialog.ShowWarning("Отмена редактирования", "Редактирование работника");
        }
        #endregion

        #region Создание работника
        private ICommand _CreateEmployeeCommand;
        public ICommand CreateEmployeeCommand => _CreateEmployeeCommand ??= new LambdaCommand(OnCreateEmployeeCommandExecuted, CanCreateEmployeeCommandExecute);
        private bool CanCreateEmployeeCommandExecute(object p) => p is Departament;
        private void OnCreateEmployeeCommandExecuted(object p)
        {
            var departament = (Departament)p;
            var employee = new Employee { Dep_Id = departament.Id };
            if (_UserDialog.Create(employee))
            {
                Employees.Add(employee);
                Departaments.FirstOrDefault(d => d.Id == departament.Id).Employees.Add(employee);
                _UserDialog.ShowInfo("Работник успешно добавлен", "Добавление работника");
                return;
            }
            if (_UserDialog.Confirm("Не удалось создать работника. \n Повторить?", "Добавление работника"))
                OnCreateEmployeeCommandExecuted(p);
        }
        #endregion

        #region Удаление работника
        private ICommand _RemoveEmployeeCommand;
        public ICommand RemoveEmployeeCommand => _RemoveEmployeeCommand ??= new LambdaCommand(OnRemoveEmployeeCommandExecuted, CanRemoveEmployeeCommandExecute);
        private bool CanRemoveEmployeeCommandExecute(object p) => p is Employee;
        private void OnRemoveEmployeeCommandExecuted(object p)
        {
            if (_UserDialog.Confirm("Вы действительно хотите удалить работника из подразделения?", "Удаление работника"))
            {
                var employee = (Employee)p;
                Employees.Remove(employee);
                Departaments.FirstOrDefault(d => d.Id == SelectedDepartament.Id).Employees.Remove(employee);
                _UserDialog.ShowInfo("Работник успешно удален", "Удаление работника");
            }
        }
        #endregion

        #region Создание подразделения
        private ICommand _CreateDepartamentCommand;
        public ICommand CreateDepartamentCommand => _CreateDepartamentCommand ??= new LambdaCommand(OnCreateDepartamentCommandExecuted, CanCreateDepartamentCommandExecute);
        private bool CanCreateDepartamentCommandExecute(object p) => true;
        private void OnCreateDepartamentCommandExecuted(object p)
        {
            var departament = new Departament{ Employees = new List<Employee>() };
            if(_UserDialog.Create(departament))
            {
                Departaments.Add(departament);
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
            if (_UserDialog.Confirm("Вы действительно хотите удалить подразделение?", "Удаление подразделения"))
            {
                var departament = (Departament)p;
                //var empls = Employees.Where(e => e.Dep_Id == departament.Id);
                Departaments.Remove(departament);
                _UserDialog.ShowInfo("Подразделение успешно удалено", "Удаление подразделения");
            }
        }
        #endregion

        #endregion

        public MainWindowViewModel(EmployeesManager EmployeesManager, IUserDialogService UserDialogService)
        {
            _EmployeesManager = EmployeesManager;
            _UserDialog = UserDialogService;

            Departaments = new ObservableCollection<Departament>(_EmployeesManager.DepGetAll());
            Departaments.CollectionChanged += Departament_CollectionChanged;

            Employees = new ObservableCollection<Employee>(_EmployeesManager.EmplGetAll());
            Employees.CollectionChanged += Employee_CollectionChanged;

        }

        #region Обработчики Событий
        private void Departament_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Departament newDepartament = e.NewItems[0] as Departament;
                    _EmployeesManager.Add(newDepartament);
                    OnPropertyChanged(nameof(Employees));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Departament oldDepartament = e.OldItems[0] as Departament;
                     _EmployeesManager.Remove(oldDepartament);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Departament replacingDepartament = e.NewItems[0] as Departament;
                    _EmployeesManager.Update(replacingDepartament.Id, replacingDepartament);
                    break;
            }
        }
        private void Employee_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Employee newEmployee = e.NewItems[0] as Employee;
                    _EmployeesManager.Add(newEmployee);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Employee oldEmployee = e.OldItems[0] as Employee;
                    _EmployeesManager.Remove(oldEmployee);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Employee replacingEmployee = e.NewItems[0] as Employee;
                    _EmployeesManager.Update(replacingEmployee.Id, replacingEmployee);
                    break;
            }
        }
        #endregion
    }
}