using AutoMapper;
using server.Contracts;
using server.DTO;
using server.Models;

namespace server.Repository
{
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
        private readonly IMapper _mapper;
        public EquipmentRepository(MyDBContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }
        public IEnumerable<Equipment> GetAllEquipment(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Equipment GetEquipment(Guid id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
        public Equipment CreateEquipment(EquipmentForCreationDto equipment, Guid WarehouseId, bool trackChanges)
        {
            var equipmentEntity = _mapper.Map<Equipment>(equipment);
            equipmentEntity.WarehouseId = WarehouseId;

            Create(equipmentEntity);

            return equipmentEntity;
        }
        public void DeleteEquipment(Guid Id, bool trackChanges)
        {
            var equipment = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            Delete(equipment);
            _context.SaveChanges();
        }
        public void UpdateEquipment(Guid Id, EquipmentForCreationDto equipmentForUpdate, bool trackChanges)
        {
            var equipmentEntity = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            _mapper.Map(equipmentForUpdate, equipmentEntity);
            _context.SaveChanges();
        }
        public EquipmentPagedResult GetEquipmentWithPagination(int limit, int offset, bool trackChanges)
        {
            var equipment = _context.MachineryEquipment
                .Skip(offset)
                .Take(limit)
                .ToList();

            var totalCount = _context.MachineryEquipment.Count();

            return new EquipmentPagedResult
            {
                Equipment = equipment,
                TotalCount = totalCount
            };
        }
    }
}
