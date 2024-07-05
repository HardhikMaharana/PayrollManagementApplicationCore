using AuthorizationAndAuthenticationProject.DataModels;

namespace AuthorizationAndAuthenticationProject.Services
{
    public interface IAuthService
    {
        Task<ApiResult> UserRegistration(RegisterUser user);
        Task<ApiResult> UserLogin(LoginUser loginUser);
        Task<ApiResult> ValidateRefreshToken(RefreshTokenmodel refresh);
    }
}