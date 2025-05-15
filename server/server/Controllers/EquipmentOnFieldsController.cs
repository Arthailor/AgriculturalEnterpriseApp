using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("api/equipmentonfields")]
    public class EquipmentOnFieldsController : ControllerBase
    {
        private readonly IEquipmentOnFieldsRepository _equipmentonfieldsRepository;
        public EquipmentOnFieldsController(IEquipmentOnFieldsRepository equipmentonfieldsRepository)
        {
            _equipmentonfieldsRepository = equipmentonfieldsRepository;
        }
        [HttpGet]
        public IActionResult GetAllEquipmentOnFields()
        {
            var equipmentonfields = _equipmentonfieldsRepository.GetAllEquipmentOnFields(trackChanges: false);
            return Ok(equipmentonfields);
        }
    }
}
