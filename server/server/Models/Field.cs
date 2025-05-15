using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Field
    {
        [Key]
        public Guid Id { get; set; } //PK
        public double CultivatedArea { get; set; }
        public double UncultivatedArea { get; set; }
        public Guid CropId { get; set; } //FK

        //Reference
        public ICollection<Pasture> Pastures { get; } = [];
        public Crop Crop { get; set; } = null!;
        public ICollection<EquipmentOnFields> EquipmentOnFields { get; } = [];
    }
}
