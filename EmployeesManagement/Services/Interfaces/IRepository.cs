using EmployeesManagement.Model.Interfaces;
using System.Collections.Generic;

namespace EmployeesManagement.Services.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        public void Add(T Item);
        bool Remove(T Item);
        void Update(int Id, T Item);
    }
}
