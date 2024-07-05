using System.ComponentModel.DataAnnotations;

namespace AuthorizationAndAuthenticationProject.DataModels
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string UserId {  get; set; }=string.Empty;
        public int DeptId { get; set; }
        public int DesignId { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
