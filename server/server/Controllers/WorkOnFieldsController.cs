using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("api/workonfields")]
    public class WorkOnFieldsController : ControllerBase
    {
        private readonly IWorkOnFieldsRepository _workonfieldsRepository;
        public WorkOnFieldsController(IWorkOnFieldsRepository workonfieldsRepository)
        {
            _workonfieldsRepository = workonfieldsRepository;
        }
        [HttpGet]
        public IActionResult GetAllWorkOnFields()
        {
            var workonfields = _workonfieldsRepository.GetAllWorkOnFields(trackChanges: false);
            return Ok(workonfields);
        }
        [HttpGet("{EmployeeId:guid}&{FieldId:guid}", Name = "GetWorkOnFields")]
        public IActionResult GetWorkOnFields(Guid EmployeeId, Guid FieldId)
        {
            var workonfields = _workonfieldsRepository.GetWorkOnFields(EmployeeId, FieldId, trackChanges: false);
            return Ok(workonfields);
        }
        [HttpPost]
        public IActionResult CreateWorkOnFields(Guid EmployeeId, Guid FieldId)
        {
            var workonfields = _workonfieldsRepository.CreateWorkOnFields(EmployeeId, FieldId, trackChanges: false);
            return CreatedAtRoute("GetWorkOnFields", new { EmployeeId = workonfields.EmployeeId, FieldId = workonfields.FieldId }, workonfields);
        }
        [HttpDelete("{EmployeeId:guid}&{FieldId:guid}")]
        public IActionResult DeleteWorkOnFields(Guid EmployeeId, Guid FieldId)
        {
            _workonfieldsRepository.DeleteWorkOnFields(EmployeeId, FieldId, false);
            return NoContent();
        }
    }
}
