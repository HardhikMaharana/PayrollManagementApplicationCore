using PayrollManagementApplication.DataModels;

namespace AuthorizationAndAuthenticationProject.Services
{
    public interface IEmployeeServices
    {
        Task<ApiResult> AddEmployee(EmployeeViewModel emp);
        Task<ApiResult> DeleteEmployee(int id);
        Task<ApiResult> GetAllEmployee();
        Task<ApiResult> GetEmployee(int id);
        Task<ApiResult> UpdateEmployee(EmployeeViewModel emp);
    }
}