using EmployeesManagement.Model.Interfaces;
using EmployeesManagement.Services.Interfaces;

namespace EmployeesManagement.Services.Base
{
    internal class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly EmployeedDbContextFactory _Context;
        protected Repository() { }
        public Repository(EmployeedDbContextFactory Context)
        {
            if (Context is null) return;
            _Context = Context;
        }
        public void Add(T Item)
        {
            using (EmployeesDbContext context = _Context.CreateDbContext())
            {
                context.Add(Item);
                context.SaveChanges();
            }
        }
        public bool Remove(T Item)
        {
            using (EmployeesDbContext context = _Context.CreateDbContext())
            {
                context.Remove(Item);
                context.SaveChanges();
                return true;
            }
        }
        public void Update(int Id, T Item)
        {
            using (EmployeesDbContext context = _Context.CreateDbContext())
            {
                Item.Id = Id;
                context.Update(Item);
                context.SaveChanges();
            }
        }
    }
}
