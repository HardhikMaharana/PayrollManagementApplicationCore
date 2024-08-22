using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollManagementApplication.DataModels;

namespace AuthorizationAndAuthenticationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    [EnableCors("AllowAll")]
    public class DepartmentController : ControllerBase
    {
        ApplicationDbContext _context;
        private readonly DepartmentReposatory _deptReposatory;

       public DepartmentController(ApplicationDbContext context,DepartmentReposatory deptReposatory) { 
        _context = context;
            _deptReposatory = deptReposatory;
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
            await _deptReposatory.AddDepartment(department);
            //var message= new Result { Status = "Employee Created Successfully" };
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetListOfDepartment()
        {
           var employeelist= await _deptReposatory.GetListOfDepartment();
            //var message= new Result { Status = "Employee Created Successfully" };
            return Ok(employeelist);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var department = await _deptReposatory.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, [FromBody] Department department)
        {
            await _deptReposatory.UpdateDepartment(id, department);
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            await _deptReposatory.DeleteDepartment(id);
            return Ok();
        }




    }
}
