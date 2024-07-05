using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationAndAuthenticationProject.DataModels
{
    public class Department
    {
        [Key]
        public int DeptId{ get; set; }
        public string DeptName { get; set; } = string.Empty;
        public string DeptCode { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; } 
    }
}
