using AuthorizationAndAuthenticationProject.Services;
using PayrollManagementApplication.DataModels;

namespace PayrollManagementApplication.Services
{
    public interface ISalaryService
    {
        Task<ApiResult> AddSalary(Salary salary);
    }
}