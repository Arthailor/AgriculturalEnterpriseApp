using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class PastureConfiguration : IEntityTypeConfiguration<Pasture>
    {
        public void Configure(EntityTypeBuilder<Pasture> builder)
        {
            builder.HasData
            (
                new Pasture
                {
                    Id = new Guid("66666666-6666-6666-6666-666666666666"),
                    Area = 5.5,
                    FieldId = new Guid("44444444-4444-4444-4444-444444444444")
                }
            );
        }
    }
}
