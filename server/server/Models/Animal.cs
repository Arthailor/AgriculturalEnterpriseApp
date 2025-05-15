using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace server.Models
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; } //PK
        public int Amount { get; set; }
        public string Name { get; set; }
        public Guid PastureId { get; set; } //FK

        //Reference
        public Pasture Pasture { get; set; } = null!;
    }
}
