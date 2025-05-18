using server.Models;

namespace server.DTO
{
    public class EquipmentPagedResult
    {
        public IEnumerable<Equipment> Equipment { get; set; }
        public int TotalCount { get; set; }
    }
}
