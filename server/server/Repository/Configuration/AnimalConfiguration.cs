using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasData
            (
                new Animal
                {
                    Id = new Guid("11111111-1111-1111-1111-111111111111"),
                    Amount = 12,
                    Name = "Овцы",
                    PastureId = new Guid("66666666-6666-6666-6666-666666666666")
                }
            );
        }
    }
}
