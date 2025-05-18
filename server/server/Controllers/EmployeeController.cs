using server.Contracts;
using server.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.DTO;

namespace server.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees(trackChanges: false);
            return Ok(employees);
        }
        [HttpGet("{id:guid}", Name = "GetEmployee")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeRepository.GetEmployee(id, trackChanges: false);
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
            {
                return BadRequest("EmployeeForCreationDto object is null");
            }
            var employeeToReturn = _employeeRepository.CreateEmployee(employee, false);
            return CreatedAtRoute("GetEmployee", new { id = employeeToReturn.Id }, employeeToReturn);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            _employeeRepository.DeleteEmployee(id, false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");
            _employeeRepository.UpdateEmployee(id, employee, true);
            return NoContent();
        }
    }
}
