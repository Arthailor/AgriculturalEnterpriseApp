using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasData
            (
                new Field
                {
                    Id = new Guid("44444444-4444-4444-4444-444444444444"),
                    CultivatedArea = 25.5,
                    UncultivatedArea = 4.5,
                    CropId = new Guid("22222222-2222-2222-2222-222222222222")
                }
            );
        }
    }
}
