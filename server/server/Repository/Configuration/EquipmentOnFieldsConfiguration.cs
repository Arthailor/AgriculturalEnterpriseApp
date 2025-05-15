using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class EquipmentOnFieldsConfiguration : IEntityTypeConfiguration<EquipmentOnFields>
    {
        public void Configure(EntityTypeBuilder<EquipmentOnFields> builder)
        {
            builder.HasKey(k => new {k.EquipmentId, k.FieldId});
            builder.HasData
            (
                new EquipmentOnFields
                {
                    EquipmentId = new Guid("55555555-5555-5555-5555-555555555555"),
                    FieldId = new Guid("44444444-4444-4444-4444-444444444444")
                }
            );
        }
    }
}
