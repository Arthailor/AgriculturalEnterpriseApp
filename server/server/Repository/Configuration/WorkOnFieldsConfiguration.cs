using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class WorkOnFieldsConfiguration : IEntityTypeConfiguration<WorkOnFields>
    {
        public void Configure(EntityTypeBuilder<WorkOnFields> builder)
        {
            builder.HasKey(k => new { k.EmployeeId, k.FieldId });
            builder.HasData
            (
                new WorkOnFields
                {
                    FieldId = new Guid("44444444-4444-4444-4444-444444444444"),
                    EmployeeId = new Guid("33333333-3333-3333-3333-333333333333")
                }
            );
        }
    }
}
