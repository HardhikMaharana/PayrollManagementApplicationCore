using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollManagementApplication.DataModels;
using PayrollManagementApplication.Services;

namespace PayrollManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    [Authorize(Roles ="Admin,Employee")]
    public class SalaryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISalaryService _salary;
        public SalaryController(ApplicationDbContext context,ISalaryService salary) { 
            _context = context;
            _salary = salary;
        }
        [HttpPost("AddSalary")]
        public Task<IActionResult> AddSalary(Salary salary)
        {
            try
            {
                _salary.AddSalary(salary);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }
        
    }
}
