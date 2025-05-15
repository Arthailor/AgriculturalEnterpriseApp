using server.Contracts;
using server.Models;

namespace server.Repository
{
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(MyDBContext context) : base(context) { }
        public IEnumerable<Equipment> GetAllEquipment(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Equipment GetEquipment(int id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
    }
}
