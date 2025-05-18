using server.Models;

namespace server.DTO
{
    public class FieldPagedResult
    {
        public IEnumerable<Field> Fields { get; set; }
        public int TotalCount { get; set; }
    }
}
