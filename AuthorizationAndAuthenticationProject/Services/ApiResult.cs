namespace AuthorizationAndAuthenticationProject.Services
{
    public class ApiResult : IApiResult
    {
        public object? Data { get; set; }
        public string? Message { get; set; }
        public bool? IsSuccessful { get; set; }
        public int? StatusCode { get; set; }
        public string RefreshToken { get; set; }=string.Empty;
        public string AccessToken {  get; set; }=string.Empty;
    }
}
