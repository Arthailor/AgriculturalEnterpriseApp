using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasData
            (
                new Equipment
                {
                    Id = new Guid("55555555-5555-5555-5555-555555555555"),
                    Name = "Трактор",
                    DateBought = new DateTime(2024, 11, 3),
                    WarehouseId = new Guid("88888888-8888-8888-8888-888888888888")
                }
            );
        }
    }
}
