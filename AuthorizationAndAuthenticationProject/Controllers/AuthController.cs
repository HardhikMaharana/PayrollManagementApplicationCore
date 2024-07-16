using AuthorizationAndAuthenticationProject.DataModels;
using AuthorizationAndAuthenticationProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace AuthorizationAndAuthenticationProject.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
 
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
    
        public async  Task<IActionResult> Login(LoginUser LoginDetails)
        {
            var result= await _authService.UserLogin(LoginDetails);

            if (result.IsSuccessful == true)
            {
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUser Register)
        {
            var result=await _authService.UserRegistration(Register);

            if (result.IsSuccessful == true) {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
        [HttpPost("RefreshToken")]
        public  async Task<IActionResult> RefreshToken(RefreshTokenmodel refreshtoken)
        {
            var result= await _authService.ValidateRefreshToken(refreshtoken);

            if (result.IsSuccessful == true) {
                return Ok(result);
            }
            else
            {
                return Ok(result); 
            }
        }

    }
}
