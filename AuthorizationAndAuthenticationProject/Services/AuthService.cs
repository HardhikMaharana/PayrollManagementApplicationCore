using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Unicode;

namespace AuthorizationAndAuthenticationProject.Services
{
    public class AuthService : IAuthService
    {
        ApiResult api = new ApiResult();
        IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        public AuthService(UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> rolemanager, IConfiguration configuration)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _configuration = configuration;
        }
        public async Task<ApiResult> UserRegistration(RegisterUser user)
        {

            try
            {
                var isUserMailPresent = _usermanager.FindByEmailAsync(user.Email);

                if (isUserMailPresent.Result != null)
                {
                    api.IsSuccessful = false;
                    api.Message = "User Already Present";
                }
                else
                {

                    var identityUser = new ApplicationUser
                    {
                        UserName = user.UserName,
                        Email = user.Email,

                    };
                    var result = await _usermanager.CreateAsync(identityUser, user.Password);
                    if (result.Succeeded == false)
                    {
                        api.Message = "Something Went Wrong Cant Find User";
                        api.IsSuccessful = false;
                        api.StatusCode = 500;
                    }
                    var IsRolePresent = await _rolemanager.FindByNameAsync("Admin");
                    if (IsRolePresent == null)
                    {
                        await _rolemanager.CreateAsync(new IdentityRole { Name = "Admin" });
                        await _usermanager.AddToRoleAsync(identityUser, "Admin");

                        api.IsSuccessful = true;
                        api.Message = "Employee Registered Succcessfully";
                        api.StatusCode = 200;
                    }
                    else
                    {
                        var isUserRolepresent = await _rolemanager.FindByNameAsync("Employee");

                        if (isUserRolepresent == null)
                        {
                            await _rolemanager.CreateAsync(new IdentityRole { Name = "Employee" });
                            await _usermanager.AddToRoleAsync(identityUser, "Employee");
                        }
                        else
                        {
                            await _usermanager.AddToRoleAsync(identityUser, "Employee");
                        }
                        api.IsSuccessful = true;
                        api.Message = "Employee Registered Successfully";
                        api.StatusCode = 200;
                    }

                }
                return api;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
        public async Task<ApiResult> UserLogin(LoginUser user)
        {
            SessionUser session = new SessionUser();
            try
            {
                var IsvalidEmail = await _usermanager.FindByEmailAsync(user.Email);
                var IsValidUser = await _usermanager.CheckPasswordAsync(IsvalidEmail, user.Password);

                if (IsValidUser == true)
                {
                    var UserRole = await _usermanager.GetRolesAsync(IsvalidEmail);
                    api.AccessToken = GenerateToken(IsvalidEmail.UserName, IsvalidEmail.Id, UserRole.First(), IsvalidEmail.Email);
                    api.RefreshToken = RefreshToken();
                    session.UserName = IsvalidEmail.UserName;
                    session.Email=IsvalidEmail.Email;
                    api.Data = session;
                    api.IsSuccessful = true;
                    api.Message = "Login Successful";
                    
                    IsvalidEmail.RefreshTokenExpiry = DateTime.Now.AddMinutes(20);
                    IsvalidEmail.RefteshToken = api.RefreshToken;
                    await _usermanager.UpdateAsync(IsvalidEmail);
                    
                }
                else
                {
                    api.IsSuccessful = false;
                    api.Message = "Please Enter Valid Credentials!";
                }
                return api;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private async Task<ClaimsPrincipal> GetPrincipal(string token)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            var validations = new TokenValidationParameters
            {
                IssuerSigningKey = securitykey,
                ValidateLifetime = false,
                ValidateActor = false,
                ValidateAudience = false,
                ValidateIssuer = false,
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validations, out _);
        }
        public async Task<ApiResult> ValidateRefreshToken(RefreshTokenmodel refreshtokendetails)
        {

            try
            {
                var principal = await GetPrincipal(refreshtokendetails.AccessToken);

                //if (principal?.Identity?.Name == null)
                //{
                //    api.IsSuccessful = false;
                //    api.Message = "Bad Request no User Found";
                //}
                //else
                //{
                    var validUser = await _usermanager.FindByEmailAsync(refreshtokendetails.Email);
                    var UserRole = await _usermanager.GetRolesAsync(validUser);

                    if (validUser.RefteshToken == null || validUser.RefteshToken != refreshtokendetails.RefreshToken || validUser.RefreshTokenExpiry < DateTime.Now)
                    {
                        api.IsSuccessful = false;
                        api.Message = "Your Session has Expired Please Login";
                    }
                    else
                    {
                        api.AccessToken = GenerateToken(validUser.UserName, validUser.Id, UserRole.First(), validUser.Email);
                        api.RefreshToken = RefreshToken();
                        api.IsSuccessful = true;
                        api.Message = "Login Successful";
                    api.Data = new SessionUser
                    {
                        Email = validUser.Email,
                        UserName = validUser.UserName,
                    };
                        validUser.RefreshTokenExpiry = DateTime.Now.AddMinutes(20);
                        validUser.RefteshToken = api.RefreshToken;
                        await _usermanager.UpdateAsync(validUser);
                    }

                //}
                return api;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private string GenerateToken(string name, string Id, string Role, string email)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var userclaims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Name,name??""),
                new Claim(JwtRegisteredClaimNames.NameId,Id??""),
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim("role",Role)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:issuer"],
                audience: _configuration["Jwt:audience"],
                claims: userclaims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string RefreshToken()
        {
            var refreshtoken = new byte[64];
            using (var randomnum = RandomNumberGenerator.Create())
            {
                randomnum.GetBytes(refreshtoken);
            }
            return Convert.ToBase64String(refreshtoken);
        }
    }
}
