using EmployeesManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesManagement.Services.ModelConfiguration
{
    internal class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasOne(d => d.Departament)
                .WithMany(e => e.Employees)
                .HasForeignKey(fk => fk.Dep_Id)
                .HasPrincipalKey(d => d.Id);
        }
    }
}
