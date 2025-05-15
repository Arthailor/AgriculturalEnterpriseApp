using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllFields()
        {
            var fields = _fieldRepository.GetAllFields(trackChanges: false);
            return Ok(fields);
        }
    }
}
