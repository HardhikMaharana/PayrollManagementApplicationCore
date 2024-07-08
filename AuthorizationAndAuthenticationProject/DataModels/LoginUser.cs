namespace AuthorizationAndAuthenticationProject.DataModels
{
    public class LoginUser
    {

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }=string.Empty;
    }
    public class RefreshTokenmodel
    {
        public string Email { get; set; } = string.Empty;
        public string AccessToken { get; set; }=string.Empty;
        public string RefreshToken { get; set; }=string.Empty;
    }
    public class SessionUser
    {
        public string Email { get; set; } = string.Empty;
        public string UserName {  get; set; } = string.Empty;
    }
}
