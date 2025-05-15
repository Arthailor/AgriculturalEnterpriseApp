using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Warehouse
    {
        [Key]
        public Guid Id { get; set; } //PK
        public DateTime UpdatedAt { get; set; }

        //Reference
        public ICollection<Equipment> MachineryEquipment { get; } = [];
    }
}
