using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationAndAuthenticationProject.Services
{
    public class EmployeeServices
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<IdentityUser> _userManager;
        public EmployeeServices(ApplicationDbContext context,RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager) { 
         _context = context;
         _rolemanager = roleManager;
         _userManager = userManager;
        }

    }
}
