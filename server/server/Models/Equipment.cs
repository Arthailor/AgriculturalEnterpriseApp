using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Equipment
    {
        [Key]
        public Guid Id { get; set; } //PK
        public string Name { get; set; }
        public DateTime DateBought { get; set; }
        public Guid WarehouseId { get; set; } //FK

        //Reference
        public Warehouse Warehouse { get; set; } = null!;
        public ICollection<EquipmentOnFields> EquipmentOnFields { get; } = [];
        public ICollection<RepairLog> RepairLogs { get; } = [];
    }
}