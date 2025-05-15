using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasData
            (
                new Warehouse
                {
                    Id = new Guid("88888888-8888-8888-8888-888888888888"),
                    UpdatedAt = new DateTime(2024, 11, 6)
                }
            );
        }
    }
}
