using PayrollManagementApplication.DataModels;

namespace AuthorizationAndAuthenticationProject.Services
{
    public interface IEmployeeServices
    {
        Task<ApiResult> AddEmployee(EmployeeViewModel emp);
        Task<ApiResult> GetEmployee(int id);
    }
}