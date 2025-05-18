using AutoMapper;
using server.Contracts;
using server.DTO;
using server.Models;

namespace server.Repository
{
    public class PastureRepository : RepositoryBase<Pasture>, IPastureRepository
    {
        private readonly IMapper _mapper;
        public PastureRepository(MyDBContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }
        public IEnumerable<Pasture> GetAllPastures(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Pasture GetPasture(Guid id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }

        public Pasture CreatePasture(PastureForCreationDto pasture, Guid FieldId, bool trackChanges)
        {
            var pastureEntity = _mapper.Map<Pasture>(pasture);
            pastureEntity.FieldId = FieldId;

            Create(pastureEntity);

            return pastureEntity;
        }
        public void DeletePasture(Guid Id, bool trackChanges)
        {
            var pasture = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            Delete(pasture);
            _context.SaveChanges();
        }
        public void UpdatePasture(Guid Id, PastureForCreationDto pastureForUpdate, bool trackChanges)
        {
            var pastureEntity = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            _mapper.Map(pastureForUpdate, pastureEntity);
            _context.SaveChanges();
        }
        public PasturePagedResult GetPasturesWithPagination(int limit, int offset, bool trackChanges)
        {
            var pastures = _context.Pastures
                .Skip(offset)
                .Take(limit)
                .ToList();

            var totalCount = _context.Pastures.Count();

            return new PasturePagedResult
            {
                Pastures = pastures,
                TotalCount = totalCount
            };
        }
    }
}
