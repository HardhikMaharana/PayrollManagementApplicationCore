using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace PayrollManagementApplication.Services
{
    public class LoginDetailsService : ILoginDetailsService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginDetailsService(IHttpContextAccessor contextaccessor)
        {
            _contextAccessor = contextaccessor;
        }

        public string UserId()
        {
            var userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return userId;
        }


    }
}
