using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmergencyContactName { get; set; }

        [Required]
        [MaxLength(20)]
        public string EmergencyContactPhone { get; set; }

        [Required]
        [MaxLength(20)]
        public string MaritalStatus { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(100)]
        public string Department { get; set; }

        [Required]
        [MaxLength(20)]
        public string EmploymentType { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public int SupervisorID { get; set; }

        [Required]
        [MaxLength(20)]
        public string EmploymentStatus { get; set; }

        [Required]
        [MaxLength(20)]
        public string BankAccountNumber { get; set; }

        [Required]
        [MaxLength(225)]
        public string BankName { get; set; }
        [Required]
        [MaxLength(225)]
        public string Branch { get; set; }
        [Required]
        [MaxLength(225)]
        public string IFSC { get; set; }
        [Required]
        [MaxLength(225)]
        public string BranchCode { get; set; }
        [Required]
        [MaxLength(20)]
        public string TaxID { get; set; }

        [Required]
        [Column(TypeName = "decimal(15, 2)")]
        public decimal Salary { get; set; }

        [Required]
        [MaxLength(20)]
        public string PayFrequency { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? HourlyRate { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? OvertimeRate { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? Bonus { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? Deductions { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? TaxWithholding { get; set; }

        [Required]
        [MaxLength(100)]
        public string HealthInsuranceProvider { get; set; }

        [Required]
        [MaxLength(100)]
        public string HealthInsurancePlan { get; set; }

        [Required]
        [MaxLength(100)]
        public string RetirementPlan { get; set; }

        [Required]
        public int LeaveBalance { get; set; }

        [Required]
        public int SickLeaveBalance { get; set; }

        [Required]
        public int VacationLeaveBalance { get; set; }

        public DateTime? LastPerformanceReviewDate { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal PerformanceScore { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public TimeSpan? TimeOut { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? TotalHoursWorked { get; set; }

        [MaxLength(255)]
        public string? ProfilePicture { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
