using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationAndAuthenticationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ApplicationDbContext _context;

       public EmployeeController(ApplicationDbContext context) { 
        _context = context;
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
    }
}
