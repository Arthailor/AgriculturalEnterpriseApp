using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.DTO;

namespace server.Controllers
{
    [ApiController]
    [Route("api/crops")]
    public class CropController : ControllerBase
    {
        private readonly ICropRepository _cropRepository;
        public CropController(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }
        [HttpGet]
        public IActionResult GetAllCrops([FromQuery] int page = 1, [FromQuery] int limit = 9)
        {
            if (page <= 0 || limit <= 0)
                return BadRequest("Page and limit must be greater than 0.");

            int offset = (page - 1) * limit;

            var cropsWithCount = _cropRepository.GetCropsWithPagination(limit, offset, trackChanges: false);

            return Ok(new
            {
                count = cropsWithCount.TotalCount,
                rows = cropsWithCount.Crops
            });
        }
        [HttpGet("{id:guid}", Name = "GetCrop")]
        public IActionResult GetCrop(Guid id)
        {
            var crop = _cropRepository.GetCrop(id, trackChanges: false);
            return Ok(crop);
        }
        [HttpPost]
        public IActionResult CreateCrop([FromBody] CropForCreationDto crop)
        {
            if (crop is null)
            {
                return BadRequest("CropForCreationDto object is null");
            }
            var cropToReturn = _cropRepository.CreateCrop(crop, false);
            return CreatedAtRoute("GetCrop", new { id = cropToReturn.Id }, cropToReturn);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCrop(Guid id)
        {
            _cropRepository.DeleteCrop(id, false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateCrop(Guid id, [FromBody] CropForCreationDto crop)
        {
            if (crop is null)
                return BadRequest("CropForCreationDto object is null");
            _cropRepository.UpdateCrop(id, crop, true);
            return NoContent();
        }
    }
}
