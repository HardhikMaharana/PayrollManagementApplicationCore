using Microsoft.AspNetCore.Identity;

namespace AuthorizationAndAuthenticationProject.DataModels
{
    public class ApplicationUser:IdentityUser
    {
            public string RefteshToken { get;set; }=string.Empty;
        public DateTime RefreshTokenExpiry { get;set; }
        public bool IsActive { get;set; }
        public string Name { get;set; }=string.Empty;
    }
}
