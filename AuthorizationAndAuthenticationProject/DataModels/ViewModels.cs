namespace PayrollManagementApplication.DataModels
{
    public class ViewModels
    {
   
    }
    public class EmployeeViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public int DptId { get; set; }
        public int DesignId { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Password { get; set; }
    }
}
