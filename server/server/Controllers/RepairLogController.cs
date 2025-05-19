using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.DTO;

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
        public IActionResult GetAllRepairLogs([FromQuery] int page = 1, [FromQuery] int limit = 9)
        {
            if (page <= 0 || limit <= 0)
                return BadRequest("Page and limit must be greater than 0.");

            int offset = (page - 1) * limit;

            var repairlogsWithCount = _repairlogRepository.GetRepairLogsWithPagination(limit, offset, trackChanges: false);

            return Ok(new
            {
                count = repairlogsWithCount.TotalCount,
                rows = repairlogsWithCount.RepairLogs
            });
        }
        [HttpGet("{id:guid}", Name = "GetRepairLog")]
        public IActionResult GetRepairLog(Guid id)
        {
            var repairlog = _repairlogRepository.GetRepairLog(id, trackChanges: false);
            return Ok(repairlog);
        }
        [HttpPost]
        public IActionResult CreateRepairLog(Guid EquipmentId, Guid EmployeeId, [FromBody] RepairLogForCreationDto repairlog)
        {
            if (repairlog is null)
            {
                return BadRequest("RepairLogForCreationDto object is null");
            }
            var repairlogToReturn = _repairlogRepository.CreateRepairLog(repairlog, EquipmentId, EmployeeId, false);
            return CreatedAtRoute("GetRepairLog", new { id = repairlogToReturn.Id, EquipmentId = EquipmentId, EmployeeId = EmployeeId }, repairlogToReturn);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteRepairLog(Guid id)
        {
            _repairlogRepository.DeleteRepairLog(id, false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateRepairLog(Guid id, [FromBody] RepairLogForCreationDto repairlog)
        {
            if (repairlog is null)
                return BadRequest("RepairLogForCreationDto object is null");
            _repairlogRepository.UpdateRepairLog(id, repairlog, true);
            return NoContent();
        }
    }
}
