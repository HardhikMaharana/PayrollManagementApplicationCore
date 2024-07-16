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
    [Authorize(Roles ="Admin")]
    public class EmployeeController : ControllerBase
    {
    private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices) { 
            _employeeServices = employeeServices;
        }
        [HttpGet("AllEmployees")]
        public IActionResult GetAllEmployees() { 
        return Ok(_employeeServices.GetAllEmployee());
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel emp)
        {
            var result = await _employeeServices.AddEmployee(emp);

            if (result == null || result.IsSuccessful==false) {
                return BadRequest(result);
            }
            else{
                return Ok(result);
            }
            

        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result=_employeeServices.GetEmployee(id);
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
        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel emp)
        {
            var result =  _employeeServices.UpdateEmployee(emp);
            if (result == null || result.IsSuccessful == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
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
