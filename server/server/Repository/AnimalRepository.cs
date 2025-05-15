using AutoMapper;
using server.Contracts;
using server.DTO;
using server.Models;

namespace server.Repository
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        private readonly IMapper _mapper;
        public AnimalRepository(MyDBContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }
        public IEnumerable<Animal> GetAllAnimals(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Animal GetAnimal(Guid id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
        public Animal CreateAnimal(AnimalForCreationDto animal ,Guid PastureId, bool trackChanges)
        {
            var animalEntity = _mapper.Map<Animal>(animal);
            animalEntity.PastureId = PastureId;

            Create(animalEntity);

            return animalEntity;
        }
        public void DeleteAnimal(Guid Id, bool trackChanges)
        {
            var animal = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            Delete(animal);
            _context.SaveChanges();
        }
        public void UpdateAnimal(Guid Id, AnimalForCreationDto animalForUpdate, bool trackChanges)
        {
            var animalEntity = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            _mapper.Map(animalForUpdate, animalEntity);
            _context.SaveChanges();
        }
        public AnimalPagedResult GetAnimalsWithPagination(int limit, int offset, bool trackChanges)
        {
            var animals = _context.Animals
                .Skip(offset)
                .Take(limit)
                .ToList();

            var totalCount = _context.Animals.Count();

            return new AnimalPagedResult
            {
                Animals = animals,
                TotalCount = totalCount
            };
        }
    }
}
