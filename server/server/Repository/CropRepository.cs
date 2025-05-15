using server.Contracts;
using server.Models;

namespace server.Repository
{
    public class CropRepository : RepositoryBase<Crop>, ICropRepository
    {
        public CropRepository(MyDBContext context) : base(context) { }
        public IEnumerable<Crop> GetAllCrops(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Crop GetCrop(int id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
    }
}
