using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class WorkOnFields
    {
        public Guid FieldId { get; set; } //PFK
        public Guid EmployeeId { get; set; } //PFK

        //Reference
        public Field Field { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}