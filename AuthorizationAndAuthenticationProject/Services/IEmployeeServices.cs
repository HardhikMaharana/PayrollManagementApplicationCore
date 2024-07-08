using PayrollManagementApplication.DataModels;

namespace AuthorizationAndAuthenticationProject.Services
{
    public interface IEmployeeServices
    {
        Task<ApiResult> AddEmployee(EmployeeViewModel emp);
        ApiResult GetEmployee(int id);
        ApiResult UpdateEmployee(EmployeeViewModel emp);
        ApiResult DeleteEmployee(int id);
    }
}