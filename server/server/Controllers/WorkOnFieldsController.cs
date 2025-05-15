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
    }
}
