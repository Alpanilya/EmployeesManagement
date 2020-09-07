using EmployeesManagement.Model.Interfaces;
using System.Collections.Generic;

namespace EmployeesManagement.Model
{
    internal class Departament: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
