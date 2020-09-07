using EmployeesManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesManagement.Services.ModelConfiguration
{
    internal class DepartamentConfiguration: IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder
                .Property(d => d.Id)
                .UseIdentityAlwaysColumn();
        }
    }
}
