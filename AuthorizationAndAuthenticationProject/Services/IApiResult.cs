namespace AuthorizationAndAuthenticationProject.Services
{
    public interface IApiResult
    {
        object? Data { get; set; }
        bool? IsSuccessful { get; set; }
        string? Message { get; set; }
        int? StatusCode { get; set; }
    }
}