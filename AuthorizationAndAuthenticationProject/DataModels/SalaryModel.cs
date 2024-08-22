using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagementApplication.DataModels
{
    [Table("TblSalary")]
    public class Salary
    {
        public int Id { get; set; }
        public string PayToUserID { get; set; }
        public long SalaryAmount { get; set; }
        public int SalaryType { get; set; }
        public int SalaryTypeId { get; set; }
        public string SalaryName { get; set; }
        public string SalaryDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string? CreatedBy { get;set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get;set; }

    }
}
