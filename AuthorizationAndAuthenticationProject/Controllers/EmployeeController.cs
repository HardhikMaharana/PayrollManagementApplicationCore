using AuthorizationAndAuthenticationProject.DataModels;
using AuthorizationAndAuthenticationProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollManagementApplication.DataModels;

namespace PayrollManagementApplication.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowAll")]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices) {
            _employeeServices = employeeServices;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("AllEmployees")]
   
        public async Task<IActionResult> GetAllEmployees() {
            return Ok(await _employeeServices.GetAllEmployee());
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
            var result =await _employeeServices.GetEmployee(id);
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
            var result = await _employeeServices.UpdateEmployee(emp);
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
            var result =await _employeeServices.DeleteEmployee(id);
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
