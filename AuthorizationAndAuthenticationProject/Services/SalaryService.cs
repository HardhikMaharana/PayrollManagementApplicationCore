using AuthorizationAndAuthenticationProject.DataModels;
using AuthorizationAndAuthenticationProject.Migrations;
using AuthorizationAndAuthenticationProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PayrollManagementApplication.DataModels;

namespace PayrollManagementApplication.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApiResult _api =new ApiResult();
        private readonly ILoginDetailsService _loginDetailsService;
        public SalaryService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILoginDetailsService loginDetailsService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _loginDetailsService = loginDetailsService;
          
        }
        public async Task<ApiResult> AddSalary(Salary salary)
        {
            try
            {
                var IsPersonsSalaryPresent = await _context.Salary.Where(w => w.IsActive == true && w.PayToUserID == salary.PayToUserID).FirstOrDefaultAsync();
                var userID = _loginDetailsService.UserId();
                if (IsPersonsSalaryPresent == null)
                {
                    salary.IsActive = true;
                    salary.CreatedOn = DateTime.Now;
                    salary.CreatedBy =userID.ToString();

                    _context.Salary.AddAsync(salary);
                    int i=await _context.SaveChangesAsync();

                    if (i > 0)
                    {
                        _api.Message = "Salary Added Successfully";
                        _api.IsSuccessful = true;
                        _api.StatusCode = 200;
                    }
                    else
                    {
                        _api.Message = "Internal Error Can't Proccess The Request.";
                        _api.IsSuccessful = false;
                        _api.StatusCode = 400;
                    }

                }
                else
                {
                    _api.Message = "Salary Already Present For The User";
                    _api.IsSuccessful = false;
                    _api.StatusCode = 400;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _api;
        }
    }
}
