using server.Contracts;
using server.Models;

namespace server.Repository
{
    public class RepairLogRepository : RepositoryBase<RepairLog>, IRepairLogRepository
    {
        public RepairLogRepository(MyDBContext context) : base(context) { }
        public IEnumerable<RepairLog> GetAllRepairLogs(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public RepairLog GetRepairLog(int id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
    }
}
