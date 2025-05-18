using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.DTO;

namespace server.Controllers
{
    [ApiController]
    [Route("api/fields")]
    public class FieldController : ControllerBase
    {
        private readonly IFieldRepository _fieldRepository;
        public FieldController(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }
        [HttpGet]
        public IActionResult GetAllFields([FromQuery] int page = 1, [FromQuery] int limit = 9)
        {
            if (page <= 0 || limit <= 0)
                return BadRequest("Page and limit must be greater than 0.");

            int offset = (page - 1) * limit;

            var fieldsWithCount = _fieldRepository.GetFieldsWithPagination(limit, offset, trackChanges: false);

            return Ok(new
            {
                count = fieldsWithCount.TotalCount,
                rows = fieldsWithCount.Fields
            });
        }
        [HttpGet("{id:guid}", Name = "GetField")]
        public IActionResult GetField(Guid id)
        {
            var field = _fieldRepository.GetField(id, trackChanges: false);
            return Ok(field);
        }
        [HttpPost]
        public IActionResult CreateField(Guid CropId, [FromBody] FieldForCreationDto field)
        {
            if (field is null)
            {
                return BadRequest("FieldForCreationDto object is null");
            }
            var fieldToReturn = _fieldRepository.CreateField(field, CropId, false);
            return CreatedAtRoute("GetField", new { id = fieldToReturn.Id, CropId = CropId }, fieldToReturn);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteField(Guid id)
        {
            _fieldRepository.DeleteField(id, false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateField(Guid id, [FromBody] FieldForCreationDto field)
        {
            if (field is null)
                return BadRequest("FieldForCreationDto object is null");
            _fieldRepository.UpdateField(id, field, true);
            return NoContent();
        }
    }
}
