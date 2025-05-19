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
            return FindAll(trackChanges).OrderBy(x => x.FieldId).ToList();
        }
        public WorkOnFields GetWorkOnFields(Guid EmployeeId, Guid FieldId, bool trackChanges)
        {
            return FindByCondition(x => x.EmployeeId.Equals(EmployeeId) && x.FieldId.Equals(FieldId), trackChanges).SingleOrDefault();
        }
        public WorkOnFields CreateWorkOnFields(Guid EmployeeId, Guid FieldId, bool trackChanges)
        {
            var workOFEntity = new WorkOnFields();
            workOFEntity.EmployeeId = EmployeeId;
            workOFEntity.FieldId = FieldId;

            Create(workOFEntity);
            return workOFEntity;
        }
        public void DeleteWorkOnFields(Guid EmployeeId, Guid FieldId, bool trackChanges)
        {
            var workOF = FindByCondition(x => x.EmployeeId.Equals(EmployeeId) && x.FieldId.Equals(FieldId), trackChanges).SingleOrDefault();
            if (workOF != null)
            {
                Delete(workOF);
                _context.SaveChanges();
            }
        }
    }
}
