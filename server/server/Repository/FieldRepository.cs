using server.Contracts;
using server.Models;

namespace server.Repository
{
    public class FieldRepository : RepositoryBase<Field>, IFieldRepository
    {
        public FieldRepository(MyDBContext context) : base(context) { }
        public IEnumerable<Field> GetAllFields(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Field GetField(int id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
    }
}
