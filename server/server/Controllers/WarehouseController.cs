using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Models;

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
    }
}
