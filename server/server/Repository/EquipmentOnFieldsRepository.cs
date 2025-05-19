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
            return FindAll(trackChanges).OrderBy(x => x.FieldId).ToList();
        }
        public EquipmentOnFields GetEquipmentOnFields(Guid EquipmentId, Guid FieldId, bool trackChanges)
        {
            return FindByCondition(x => x.EquipmentId.Equals(EquipmentId) && x.FieldId.Equals(FieldId), trackChanges).SingleOrDefault();
        }
        public EquipmentOnFields CreateEquipmentOnFields(Guid EquipmentId, Guid FieldId, bool trackChanges)
        {
            var equipmentOFEntity = new EquipmentOnFields();
            equipmentOFEntity.EquipmentId = EquipmentId;
            equipmentOFEntity.FieldId = FieldId;

            Create(equipmentOFEntity);
            return equipmentOFEntity;
        }
        public void DeleteEquipmentOnFields(Guid EquipmentId, Guid FieldId, bool trackChanges)
        {
            var equipmentOF = FindByCondition(x => x.EquipmentId.Equals(EquipmentId) && x.FieldId.Equals(FieldId), trackChanges).SingleOrDefault();
            if (equipmentOF != null)
            {
                Delete(equipmentOF);
                _context.SaveChanges();
            }
        }
    }
}
