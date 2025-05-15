using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class EquipmentOnFields
    {
        public Guid EquipmentId { get; set; } //PFK
        public Guid FieldId { get; set; } //PFK

        //Reference
        public Field Field { get; set; } = null!;
        public Equipment Equipment { get; set; } = null!;
    }
}
