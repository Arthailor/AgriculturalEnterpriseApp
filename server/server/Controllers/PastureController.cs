using server.Contracts;
using server.DTO;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/pastures")]
    public class PastureController : ControllerBase
    {
        private readonly IPastureRepository _pastureRepository;
        public PastureController(IPastureRepository pastureRepository)
        {
            _pastureRepository = pastureRepository;
        }
        [HttpGet]
        public IActionResult GetAllPastures([FromQuery] int page = 1, [FromQuery] int limit = 9)
        {
            if (page <= 0 || limit <= 0)
                return BadRequest("Page and limit must be greater than 0.");

            int offset = (page - 1) * limit;

            var pasturesWithCount = _pastureRepository.GetPasturesWithPagination(limit, offset, trackChanges: false);

            return Ok(new
            {
                count = pasturesWithCount.TotalCount,
                rows = pasturesWithCount.Pastures
            });
        }
        [HttpGet("{id:guid}", Name = "GetPasture")]
        public IActionResult GetPasture(Guid id)
        {
            var pasture = _pastureRepository.GetPasture(id, trackChanges: false);
            return Ok(pasture);
        }
        [HttpPost]
        public IActionResult CreatePasture(Guid FieldId, [FromBody] PastureForCreationDto pasture)
        {
            if (pasture is null)
            {
                return BadRequest("PastureForCreationDto object is null");
            }
            var pastureToReturn = _pastureRepository.CreatePasture(pasture, FieldId, false);
            return CreatedAtRoute("GetPasture", new { id = pastureToReturn.Id, FieldId = FieldId }, pastureToReturn);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeletePasture(Guid id)
        {
            _pastureRepository.DeletePasture(id, false);
            return NoContent();
        }
    }
}
