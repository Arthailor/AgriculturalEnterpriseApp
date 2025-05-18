using server.Models;

namespace server.DTO
{
    public class CropPagedResult
    {
        public IEnumerable<Crop> Crops { get; set; }
        public int TotalCount { get; set; }
    }
}
