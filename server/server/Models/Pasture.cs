using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Pasture
    {
        [Key]
        public Guid Id { get; set; } //PK
        public double Area { get; set; }
        public Guid FieldId { get; set; } //FK

        //Reference
        public ICollection<Animal> Animals { get; } = [];
        public Field Field { get; set; } = null!;
    }
}
