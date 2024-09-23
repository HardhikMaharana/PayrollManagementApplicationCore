using Microsoft.AspNetCore.Mvc;
using PayrollManagementApplication.Services;

namespace PayrollManagementApplication.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILoginDetailsService _loginDetailsService;
        public BaseController() {
   
        }
        public string Userdetails()
        {
            string user = _loginDetailsService.UserId();
            return user;
        }

    }
}
