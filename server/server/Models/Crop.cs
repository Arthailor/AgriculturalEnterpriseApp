using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class Crop
    {
        [Key]
        public Guid Id { get; set; } //PK
        public string Name { get; set; }
        public int Amount { get; set; }

        //Reference
        public ICollection<Field> Fields { get; } = [];
    }
}
