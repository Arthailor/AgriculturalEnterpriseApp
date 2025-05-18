using AutoMapper;
using server.Contracts;
using server.DTO;
using server.Models;

namespace server.Repository
{
    public class WarehouseRepository : RepositoryBase<Warehouse>, IWarehouseRepository
    {
        private readonly IMapper _mapper;
        public WarehouseRepository(MyDBContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }
        public IEnumerable<Warehouse> GetAllWarehouses(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Warehouse GetWarehouse(Guid id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
        public Warehouse CreateWarehouse(WarehouseForCreationDto warehouse, bool trackChanges)
        {
            var warehouseEntity = _mapper.Map<Warehouse>(warehouse);

            Create(warehouseEntity);

            return warehouseEntity;
        }
        public void DeleteWarehouse(Guid Id, bool trackChanges)
        {
            var warehouse = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            Delete(warehouse);
            _context.SaveChanges();
        }
        public void UpdateWarehouse(Guid Id, WarehouseForCreationDto warehouseForUpdate, bool trackChanges)
        {
            var warehouseEntity = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            _mapper.Map(warehouseForUpdate, warehouseEntity);
            _context.SaveChanges();
        }
    }
}
