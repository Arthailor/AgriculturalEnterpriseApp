using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class RepairLogConfiguration : IEntityTypeConfiguration<RepairLog>
    {
        public void Configure(EntityTypeBuilder<RepairLog> builder)
        {
            builder.HasData
            (
                new RepairLog
                {
                    Id = new Guid("77777777-7777-7777-7777-777777777777"),
                    EquipmentId = new Guid("55555555-5555-5555-5555-555555555555"),
                    EmployeeId = new Guid("33333333-3333-3333-3333-333333333333"),
                    DateOfBreakage = new DateTime(2024, 11, 5),
                    DateOfRepair = new DateTime(2024, 11, 6),
                    CauseOfBreakage = "Тряска"
                }
            );
        }
    }
}
