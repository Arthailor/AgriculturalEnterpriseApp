using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
            (
                new Employee
                {
                    Id = new Guid("33333333-3333-3333-3333-333333333333"),
                    Name = "Владимир",
                    Phone = "+375123456789",
                    Address = "г. Могилёв",
                    Login = "vladimir",
                    Password = "1234",
                    Role = "Admin"
                }
            );
        }
    }
}
