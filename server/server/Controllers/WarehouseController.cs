using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DTO;

namespace server.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        [HttpGet]
        public IActionResult GetAllWarehouses()
        {
            var warehouses = _warehouseRepository.GetAllWarehouses(trackChanges: false);
            return Ok(warehouses);
        }
        [HttpGet("{id:guid}", Name = "GetWarehouse")]
        public IActionResult GetWarehouse(Guid id)
        {
            var warehouse = _warehouseRepository.GetWarehouse(id, trackChanges: false);
            return Ok(warehouse);
        }
        [HttpPost]
        public IActionResult CreateWarehouse([FromBody] WarehouseForCreationDto warehouse)
        {
            if (warehouse is null)
            {
                return BadRequest("WarehouseForCreationDto object is null");
            }
            var warehouseToReturn = _warehouseRepository.CreateWarehouse(warehouse, false);
            return CreatedAtRoute("GetWarehouse", new { id = warehouseToReturn.Id }, warehouseToReturn);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteWarehouse(Guid id)
        {
            _warehouseRepository.DeleteWarehouse(id, false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateWarehouse(Guid id, [FromBody] WarehouseForCreationDto warehouse)
        {
            if (warehouse is null)
                return BadRequest("WarehouseForCreationDto object is null");
            _warehouseRepository.UpdateWarehouse(id, warehouse, true);
            return NoContent();
        }
    }
}
