using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PayrollManagementApplication.DataModels;

using System.Reflection.Metadata.Ecma335;

namespace AuthorizationAndAuthenticationProject.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApiResult _apiResult = new ApiResult();
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeServices(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _rolemanager = roleManager;
            _userManager = userManager;
        }

        public async Task<ApiResult> GetEmployee(int id)
        {
            try
            {
                var Employees = _context.Employees.Where(w => w.IsActive == true).ToList();

                if (Employees == null)
                {
                    _apiResult.IsSuccessful = false;
                    _apiResult.Message = "User Not Found";
                }
                else
                {
                    _apiResult.Data = Employees;
                    _apiResult.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _apiResult;
        }

        public async Task<ApiResult> AddEmployee(EmployeeViewModel emp)
        {
            Employee employees = new Employee();
            try
            {
                var isRolePresent = await _rolemanager.FindByNameAsync("Employee");
                if (isRolePresent == null)
                {
                    await _rolemanager.CreateAsync(new IdentityRole("Employee"));
                }

                var identityUser = new ApplicationUser
                {
                    Email = emp.Email,
                    UserName = emp.UserName,
                };
                var isEmployeePreset = _context.Users.Where(w => w.Email == emp.Email).FirstOrDefault();

                if (isEmployeePreset == null)
                {

                    var isUserCreated = await _userManager.CreateAsync(identityUser, emp.Password);

                    var finduser = await _userManager.FindByEmailAsync(identityUser.Email);
                    if (finduser == null)
                    {
                        _apiResult.IsSuccessful = false;
                        _apiResult.Message = "Something Went Wrong";
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(identityUser, "Employee");
                        employees.JoiningDate = emp.JoiningDate;
                        employees.DOB = emp.DOB;
                        employees.UserId = finduser.Id;
                        employees.DeptId = emp.DptId;
                        employees.DesignId = emp.DesignId;
                        employees.CreatedOn = DateTime.Now;
                        employees.IsActive = true;
                        employees.CreatedBy = "Admin";
                        _context.Employees.Add(employees);

                        var isSaved = _context.SaveChanges();
                        if (isSaved > 0)
                        {
                            _apiResult.IsSuccessful = true;
                            _apiResult.Message = "Employee Registered Successfuly";
                        }
                        else
                        {
                            _apiResult.IsSuccessful = false;
                            _apiResult.Message = "Something Went Wrong";
                        }
                    }

                }
                else
                {
                    _apiResult.IsSuccessful = false;
                    _apiResult.Message = "Employee Already Present";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _apiResult;
        }



    }
}
