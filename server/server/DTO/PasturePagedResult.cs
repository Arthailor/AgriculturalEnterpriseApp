using server.Models;

namespace server.DTO
{
    public class PasturePagedResult
    {
        public IEnumerable<Pasture> Pastures { get; set; }
        public int TotalCount { get; set; }
    }
}
