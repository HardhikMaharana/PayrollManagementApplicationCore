using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollManagementApplication.DataModels;

namespace AuthorizationAndAuthenticationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ApplicationDbContext _context;
        private readonly EmployeeRepository _employeeRepository;

       public EmployeeController(ApplicationDbContext context,EmployeeRepository employeeRepository) { 
        _context = context;
            _employeeRepository = employeeRepository;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddEmployee([FromBody]Employee emp)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
            await _employeeRepository.AddDepartment(department);
            //var message= new Result { Status = "Employee Created Successfully" };
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetListOfDepartment()
        {
           var employeelist= await _employeeRepository.GetListOfDepartment();
            //var message= new Result { Status = "Employee Created Successfully" };
            return Ok(employeelist);

        }
    }
}
