using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DTO;

namespace server.Controllers
{
    [ApiController]
    [Route("api/equipment")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        [HttpGet]
        public IActionResult GetAllEquipment([FromQuery] int page = 1, [FromQuery] int limit = 9)
        {
            if (page <= 0 || limit <= 0)
                return BadRequest("Page and limit must be greater than 0.");

            int offset = (page - 1) * limit;

            var equipmentWithCount = _equipmentRepository.GetEquipmentWithPagination(limit, offset, trackChanges: false);

            return Ok(new
            {
                count = equipmentWithCount.TotalCount,
                rows = equipmentWithCount.Equipment
            });
        }
        [HttpGet("{id:guid}", Name = "GetEquipment")]
        public IActionResult GetEquipment(Guid id)
        {
            var equipment = _equipmentRepository.GetEquipment(id, trackChanges: false);
            return Ok(equipment);
        }
        [HttpPost]
        public IActionResult CreateEquipment(Guid WarehouseId, [FromBody] EquipmentForCreationDto equipment)
        {
            if (equipment is null)
            {
                return BadRequest("EquipmentForCreationDto object is null");
            }
            var equipmentToReturn = _equipmentRepository.CreateEquipment(equipment, WarehouseId, false);
            return CreatedAtRoute("GetEquipment", new { id = equipmentToReturn.Id, CropId = WarehouseId }, equipmentToReturn);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEquipment(Guid id)
        {
            _equipmentRepository.DeleteEquipment(id, false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateEquipment(Guid id, [FromBody] EquipmentForCreationDto equipment)
        {
            if (equipment is null)
                return BadRequest("EquipmentForCreationDto object is null");
            _equipmentRepository.UpdateEquipment(id, equipment, true);
            return NoContent();
        }
    }
}
