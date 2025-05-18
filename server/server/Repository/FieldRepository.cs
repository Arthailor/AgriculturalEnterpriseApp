using AutoMapper;
using server.Contracts;
using server.DTO;
using server.Models;

namespace server.Repository
{
    public class FieldRepository : RepositoryBase<Field>, IFieldRepository
    {
        private readonly IMapper _mapper;
        public FieldRepository(MyDBContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }
        public IEnumerable<Field> GetAllFields(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Field GetField(Guid id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
        public Field CreateField(FieldForCreationDto field, Guid CropId, bool trackChanges)
        {
            var fieldEntity = _mapper.Map<Field>(field);
            fieldEntity.CropId = CropId;

            Create(fieldEntity);

            return fieldEntity;
        }
        public void DeleteField(Guid Id, bool trackChanges)
        {
            var field = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            Delete(field);
            _context.SaveChanges();
        }
        public void UpdateField(Guid Id, FieldForCreationDto fieldForUpdate, bool trackChanges)
        {
            var fieldEntity = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            _mapper.Map(fieldForUpdate, fieldEntity);
            _context.SaveChanges();
        }
        public FieldPagedResult GetFieldsWithPagination(int limit, int offset, bool trackChanges)
        {
            var fields = _context.Fields
                .Skip(offset)
                .Take(limit)
                .ToList();

            var totalCount = _context.Fields.Count();

            return new FieldPagedResult
            {
                Fields = fields,
                TotalCount = totalCount
            };
        }
    }
}
