using server.Models;

namespace server.DTO
{
    public class RepairLogPagedResult
    {
        public IEnumerable<RepairLog> RepairLogs { get; set; }
        public int TotalCount { get; set; }
    }
}
