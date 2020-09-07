
using EmployeesManagement.Model;
using EmployeesManagement.Services.Interfaces;
using EmployeesManagement.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EmployeesManagement.Services
{
    internal class WindowUserDialogService : IUserDialogService
    {
        public bool Confirm(string message, string caption, bool exlamanation = false) =>
            MessageBox.Show
                (
                message,
                caption,
                MessageBoxButton.YesNo,
                exlamanation ? MessageBoxImage.Exclamation : MessageBoxImage.Question
                )
            == MessageBoxResult.Yes;
        public void ShowError(string message, string caption) =>
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        public void ShowInfo(string information, string caption) =>
            MessageBox.Show(information, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        public void ShowWarning(string message, string caption) =>
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
        public bool Create(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            switch (item)
            {
                case Employee employee:
                    return CreateEmployee(employee);
                case Departament departament:
                    return CreateDepartament(departament);
                default:
                    throw new NotSupportedException($"Создание объекта типа {item.GetType().Name} не поддерживается");
            }
        }
        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            switch (item)
            {
                case Employee employee:
                    return EditEmployee(employee);
                default:
                    throw new NotSupportedException($"Редактирование объекта типа {item.GetType().Name} не поддерживается");
            }
        }
        private static bool CreateEmployee(Employee employee)
        {
            var dlg = new EmployeeManagerWindow()
            {
                FirstName = "Имя",
                LastName = "Фамилия",
                Age = 0,
                Position = "Должность"
            };
            if (dlg.ShowDialog() != true) return false;

            employee.FirstName = dlg.FirstName;
            employee.LastName = dlg.LastName;
            employee.Age = dlg.Age;
            employee.Position = dlg.Position;

            return true;
        }
        private static bool EditEmployee(Employee employee)
        {
            var dlg = new EmployeeManagerWindow()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Position = employee.Position
            };
            if (dlg.ShowDialog() != true) return false;

            employee.FirstName = dlg.FirstName;
            employee.LastName = dlg.LastName;
            employee.Age = dlg.Age;
            employee.Position = dlg.Position;

            return true;
        }
        private static bool CreateDepartament(Departament departament)
        {
            var dlg = new DepartamentManagerWindow()
            {
                Name = "Название подразделения"
            };
            if (dlg.ShowDialog() != true) return false;

            departament.Name = dlg.Name;

            return true;
        }

    }
}
