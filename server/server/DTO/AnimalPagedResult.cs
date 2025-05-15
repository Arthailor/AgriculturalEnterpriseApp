using server.Models;

namespace server.DTO
{
    public class AnimalPagedResult
    {
        public IEnumerable<Animal> Animals { get; set; }
        public int TotalCount { get; set; }
    }
}
