using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollManagementApplication.DataModels;

namespace PayrollManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    [EnableCors("AllowAll")]
    public class DesignationController : ControllerBase
    {


        ApplicationDbContext _applicationDbContext;
        private readonly DesignationRepository _designationRepository;

        public DesignationController(ApplicationDbContext applicationDbContext, DesignationRepository designationRepository)
        {
            _applicationDbContext = applicationDbContext;
            _designationRepository = designationRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddDesignation([FromBody] Designation designation)
        {
            await _designationRepository.AddDesignation(designation);
            //var message= new Result { Status = "Employee Created Successfully" };
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfDesignation()
        {
            var employeelist = await _designationRepository.GetListOfDesignation();
            //var message= new Result { Status = "Employee Created Successfully" };
            return Ok(employeelist);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesignationById([FromRoute] int id)
        {
            var department = await _designationRepository.GetDesignationById(id);
            return Ok(department);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDesignation([FromRoute] int id, [FromBody] Designation designation)
        {
            await _designationRepository.UpdateDesignation(id, designation);
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignation([FromRoute] int id)
        {
            await _designationRepository.DeleteDesignation(id);
            return Ok();
        }







    }
}
