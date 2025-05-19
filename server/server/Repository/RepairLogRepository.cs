using AutoMapper;
using server.Contracts;
using server.DTO;
using server.Models;

namespace server.Repository
{
    public class RepairLogRepository : RepositoryBase<RepairLog>, IRepairLogRepository
    {
        private readonly IMapper _mapper;
        public RepairLogRepository(MyDBContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }
        public IEnumerable<RepairLog> GetAllRepairLogs(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public RepairLog GetRepairLog(Guid id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
        public RepairLog CreateRepairLog(RepairLogForCreationDto repairlog, Guid EquipmentId, Guid EmployeeId, bool trackChanges)
        {
            var repairlogEntity = _mapper.Map<RepairLog>(repairlog);
            repairlogEntity.EquipmentId = EquipmentId;
            repairlogEntity.EmployeeId = EmployeeId;

            Create(repairlogEntity);

            return repairlogEntity;
        }
        public void DeleteRepairLog(Guid Id, bool trackChanges)
        {
            var repairlog = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            Delete(repairlog);
            _context.SaveChanges();
        }
        public void UpdateRepairLog(Guid Id, RepairLogForCreationDto repairlogForUpdate, bool trackChanges)
        {
            var repairlogEntity = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            _mapper.Map(repairlogForUpdate, repairlogEntity);
            _context.SaveChanges();
        }
        public RepairLogPagedResult GetRepairLogsWithPagination(int limit, int offset, bool trackChanges)
        {
            var repairlogs = _context.RepairLogs
                .Skip(offset)
                .Take(limit)
                .ToList();

            var totalCount = _context.RepairLogs.Count();

            return new RepairLogPagedResult
            {
                RepairLogs = repairlogs,
                TotalCount = totalCount
            };
        }
    }
}
