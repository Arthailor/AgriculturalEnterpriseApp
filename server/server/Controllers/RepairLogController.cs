using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("api/repairlogs")]
    public class RepairLogController : ControllerBase
    {
        private readonly IRepairLogRepository _repairlogRepository;
        public RepairLogController(IRepairLogRepository repairlogRepository)
        {
            _repairlogRepository = repairlogRepository;
        }
        [HttpGet]
        public IActionResult GetAllRepairLogs()
        {
            var repairlogs = _repairlogRepository.GetAllRepairLogs(trackChanges: false);
            return Ok(repairlogs);
        }
    }
}
