using AutoMapper;
using server.Contracts;
using server.DTO;
using server.Models;

namespace server.Repository
{
    public class CropRepository : RepositoryBase<Crop>, ICropRepository
    {
        private readonly IMapper _mapper;
        public CropRepository(MyDBContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }
        public IEnumerable<Crop> GetAllCrops(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Crop GetCrop(Guid id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
        public Crop CreateCrop(CropForCreationDto crop, bool trackChanges)
        {
            var cropEntity = _mapper.Map<Crop>(crop);

            Create(cropEntity);

            return cropEntity;
        }
        public void DeleteCrop(Guid Id, bool trackChanges)
        {
            var crop = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            Delete(crop);
            _context.SaveChanges();
        }
        public void UpdateCrop(Guid Id, CropForCreationDto cropForUpdate, bool trackChanges)
        {
            var cropEntity = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            _mapper.Map(cropForUpdate, cropEntity);
            _context.SaveChanges();
        }
        public CropPagedResult GetCropsWithPagination(int limit, int offset, bool trackChanges)
        {
            var crops = _context.SeedCrops
                .Skip(offset)
                .Take(limit)
                .ToList();

            var totalCount = _context.SeedCrops.Count();

            return new CropPagedResult
            {
                Crops = crops,
                TotalCount = totalCount
            };
        }
    }
}