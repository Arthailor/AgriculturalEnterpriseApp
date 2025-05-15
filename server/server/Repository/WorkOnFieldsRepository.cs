using server.Contracts;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class WorkOnFieldsRepository : RepositoryBase<WorkOnFields>, IWorkOnFieldsRepository
    {
        public WorkOnFieldsRepository(MyDBContext context) : base(context) { }
        public IEnumerable<WorkOnFields> GetAllWorkOnFields(bool trackChanges)
        {
            return FindAll(trackChanges).Include(x => x.Employee).Include(x => x.Field).OrderBy(x => x.FieldId).ToList();
        }
        public WorkOnFields GetWorkOnFields(Guid EmployeeId, Guid FieldId, bool trackChanges)
        {
            return FindByCondition(x => x.EmployeeId.Equals(EmployeeId) && x.FieldId.Equals(FieldId), trackChanges).Include(x => x.Field).Include(x => x.Employee).SingleOrDefault();
        }
    }
}
