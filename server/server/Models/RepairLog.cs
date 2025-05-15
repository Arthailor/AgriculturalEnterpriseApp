using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class RepairLog
    {
        [Key]
        public Guid Id { get; set; } //PK
        public Guid EquipmentId { get; set; } //FK
        public Guid EmployeeId { get; set; } //FK
        public DateTime DateOfBreakage { get; set; }
        public DateTime DateOfRepair { get; set; }
        public string CauseOfBreakage { get; set; }

        //Reference
        public Employee Employee { get; set; } = null!;
        public Equipment Equipment { get; set; } = null!;
    }
}