
namespace AuthAPI.Services
{
    public interface ILoggingService 
    {
       // Task LogInformation(string requestmethod, string requestpath, string body, string message, int responsecode);
        Task LogInformation(string method, PathString path, string body, int responsecode);
        Task LogInformation(string body, string requestmethod, string requestpath, int statuscode, string exceptionmessage);
    }
}
