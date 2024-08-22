using AuthorizationAndAuthenticationProject.DataModels;
using AuthorizationAndAuthenticationProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollManagementApplication.DataModels;

namespace PayrollManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices) {
            _employeeServices = employeeServices;
        }

        [HttpGet("AllEmployees")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllEmployees() {
            return Ok(_employeeServices.GetAllEmployee());
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel emp)
        {
            var result = await _employeeServices.AddEmployee(emp);

            if (result == null || result.IsSuccessful == false) {
                return BadRequest(result);
            }
            else {
                return Ok(result);
            }


        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetEmployee([FromRoute]int id)
        {
            var result = _employeeServices.GetEmployee(id);
            if (result == null || result.IsSuccessful == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel emp)
        {
            var result = _employeeServices.UpdateEmployee(emp);
            if (result == null || result.IsSuccessful == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]int id)
        {
            var result = _employeeServices.DeleteEmployee(id);
            if (result == null || result.IsSuccessful == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

    }
}
