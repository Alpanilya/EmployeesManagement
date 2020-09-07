
using EmployeesManagement.Model;
using EmployeesManagement.Services.Base;
using System;

namespace EmployeesManagement.Services
{
    internal class EmployeesManager
    {
        private readonly EmployeesDbContext _Context;
        private readonly Repository<Departament> _DepartamentRepository;
        private readonly Repository<Employee> _EmployeeRepository;
        public EmployeesManager(EmployeesDbContext Context)
        {
            _Context = Context;
            _DepartamentRepository = new Repository<Departament>(Context);
            _EmployeeRepository = new Repository<Employee>(Context);
        }
        public void Add(object Item)
        {
            switch (Item)
            {
                case Employee employee:
                     _EmployeeRepository.Add(employee);
                    break;
                case Departament departament:
                    _DepartamentRepository.Add(departament);
                    break;
                default:
                    throw new NotSupportedException($"Создание объекта типа {Item.GetType().Name} не поддерживается");
            }
        }
        public bool Remove(object Item)
        {
            switch (Item)
            {
                case Employee employee:
                    return _EmployeeRepository.Remove(employee);
                    
                case Departament departament:
                    return _DepartamentRepository.Remove(departament);
                default:
                    throw new NotSupportedException($"Добавление объекта типа {Item.GetType().Name} не поддерживается");
            }
        }
        public void Update(int Id, object Item)
        {
            switch (Item)
            {
                case Employee employee:
                    _EmployeeRepository.Update(Id, employee);
                    break;
                default:
                    throw new NotSupportedException($"Редактирование объекта типа {Item.GetType().Name} не поддерживается");
            }
        }
    }
}
