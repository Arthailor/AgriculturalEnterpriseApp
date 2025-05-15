using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //Reference
        public ICollection<WorkOnFields> WorkOnFields { get; } = [];
        public ICollection<RepairLog> RepairLogs { get; } = [];
    }
}