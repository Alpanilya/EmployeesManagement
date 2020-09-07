using EmployeesManagement.Model.Interfaces;

namespace EmployeesManagement.Model
{
    internal class Employee: IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int Dep_Id { get; set; }
        public Departament Departament { get; set; }
    }
}
