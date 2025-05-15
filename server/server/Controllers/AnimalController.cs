using server.Contracts;
using server.DTO;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        [HttpGet]
        public IActionResult GetAllAnimals([FromQuery] int page = 1, [FromQuery] int limit = 9)
        {
            if (page <= 0 || limit <= 0)
                return BadRequest("Page and limit must be greater than 0.");

            int offset = (page - 1) * limit;

            var animalsWithCount = _animalRepository.GetAnimalsWithPagination(limit, offset, trackChanges: false);

            return Ok(new
            {
                count = animalsWithCount.TotalCount,
                rows = animalsWithCount.Animals
            });
        }
        [HttpGet("{id:guid}", Name = "GetAnimal")]
        public IActionResult GetAnimal(Guid id)
        {
            var animal = _animalRepository.GetAnimal(id, trackChanges: false);
            return Ok(animal);
        }
        [HttpPost]
        public IActionResult CreateAnimal(Guid PastureId, [FromBody] AnimalForCreationDto animal)
        {
            if (animal is null)
            {
                return BadRequest("AnimalForCreationDto object is null");
            }
            var animalToReturn = _animalRepository.CreateAnimal(animal, PastureId, false);
            return CreatedAtRoute("GetAnimal", new { id = animalToReturn.Id, PastureId = PastureId }, animalToReturn);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAnimal(Guid id)
        {
            _animalRepository.DeleteAnimal(id, false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateAnimal(Guid id, [FromBody] AnimalForCreationDto animal)
        {
            if (animal is null)
                return BadRequest("AnimalForCreationDto object is null");
            _animalRepository.UpdateAnimal(id, animal, true);
            return NoContent();
        }
    }
}
