using System.ComponentModel.DataAnnotations;

namespace AuthorizationAndAuthenticationProject.DataModels
{
    public class Designation
    {
        [Key]
      public int DesignationId { get; set; }
        public string DesignationName { get; set; } = string.Empty;
        public string DesignationCode { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
