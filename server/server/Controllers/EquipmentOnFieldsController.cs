using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [HttpGet("{EquipmentId:guid}&{FieldId:guid}", Name = "GetEquipmentOnFields")]
        public IActionResult GetEquipmentOnFields(Guid EquipmentId, Guid FieldId)
        {
            var equipmentonfields = _equipmentonfieldsRepository.GetEquipmentOnFields(EquipmentId, FieldId, trackChanges: false);
            return Ok(equipmentonfields);
        }
        [HttpPost]
        public IActionResult CreateEquipmentOnFields(Guid EquipmentId, Guid FieldId)
        {
            var equipmentonfields = _equipmentonfieldsRepository.CreateEquipmentOnFields(EquipmentId, FieldId, trackChanges: false);
            return CreatedAtRoute("GetEquipmentOnFields", new { EquipmentId = equipmentonfields.EquipmentId, FieldId = equipmentonfields.FieldId }, equipmentonfields);
        }
        [HttpDelete("{EquipmentId:guid}&{FieldId:guid}")]
        public IActionResult DeleteEquipmentOnFields(Guid EquipmentId, Guid FieldId)
        {
            _equipmentonfieldsRepository.DeleteEquipmentOnFields(EquipmentId, FieldId, false);
            return NoContent();
        }
    }
}
