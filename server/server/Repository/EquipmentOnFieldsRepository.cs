using server.Contracts;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class EquipmentOnFieldsRepository : RepositoryBase<EquipmentOnFields>, IEquipmentOnFieldsRepository
    {
        public EquipmentOnFieldsRepository(MyDBContext context) : base(context) { }
        public IEnumerable<EquipmentOnFields> GetAllEquipmentOnFields(bool trackChanges)
        {
            return FindAll(trackChanges).Include(x => x.Equipment).Include(x => x.Field).OrderBy(x => x.FieldId).ToList();
        }
        public EquipmentOnFields GetEquipmentOnFields(Guid EquipmentId, Guid FieldId, bool trackChanges)
        {
            return FindByCondition(x => x.EquipmentId.Equals(EquipmentId) && x.FieldId.Equals(FieldId), trackChanges).Include(x => x.Field).Include(x => x.Equipment).SingleOrDefault();
        }
    }
}
