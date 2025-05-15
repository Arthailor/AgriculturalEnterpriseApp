using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class CropConfiguration : IEntityTypeConfiguration<Crop>
    {
        public void Configure(EntityTypeBuilder<Crop> builder)
        {
            builder.HasData
            (
                new Crop
                {
                    Id = new Guid("22222222-2222-2222-2222-222222222222"),
                    Amount = 12,
                    Name = "Пшеница"
                }
            );
        }
    }
}
