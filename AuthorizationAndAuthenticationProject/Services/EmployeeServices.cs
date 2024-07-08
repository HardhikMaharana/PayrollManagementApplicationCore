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

        public  ApiResult GetEmployee(int id)
        {
            try
            {
                var Employees = _context.Employees.Where(w => w.IsActive == true && w.EmployeeId==id).ToList();

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
            return  _apiResult;
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
        public  ApiResult UpdateEmployee(EmployeeViewModel emp)
        {
            try
            {
                var employee = _context.Employees.Where(w => w.IsActive == true && w.EmployeeId == emp.EmpId && w.UserId == emp.Id)
                                    .FirstOrDefault();

                if (employee != null)
                {

                }
                else
                {
                    employee.DeptId = emp.DptId;
                    employee.UpdatedOn = DateTime.Now;
                    employee.DesignId= emp.DesignId;
                    employee.UpdatedBy = "Admin";
                    employee.JoiningDate = emp.JoiningDate;
                    employee.DOB= emp.DOB;
                    _context.Employees.Add(employee);
                    var issaved=_context.SaveChanges();

                    if (issaved > 0)
                    {
                        _apiResult.Message = "Employee Updated Successfuly";
                        _apiResult.IsSuccessful = true;
                    }
                    else
                    {
                        _apiResult.Message = "Something Went Wrong";
                        _apiResult.IsSuccessful = false;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _apiResult;
        }
        public ApiResult DeleteEmployee(int id)
        {
            try
            {
                var employees = _context.Employees.Where(w => w.IsActive == true && w.EmployeeId == id).FirstOrDefault();

                if (employees == null)
                {
                    _apiResult.IsSuccessful = false;
                    _apiResult.Message = "User Not Found";
                }
                else
                {
                    employees.IsActive = false;
                    var isSaved = _context.SaveChanges();

                    if (isSaved > 0)
                    {
                        _apiResult.IsSuccessful = true;
                        _apiResult.Message = "Employee Deleted Successfully";
                    }
                    else
                    {
                        _apiResult.IsSuccessful = false;
                        _apiResult.Message = "Something Went Wrong";
                    }
                   
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
