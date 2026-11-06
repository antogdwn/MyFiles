using AuthAPI.Data;
using AuthAPI.Models;

namespace AuthAPI.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LoggingService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task LogInformation(string method, PathString path, string body, int responsecode)
        {
            var log = new APILog
            {
                //            await logger.LogInformation(context.Request.Method, context.Request.Path, context.Request.Body.ToString()!, 0);

                RequestMethod = method,
                RequestPath = path,
                Message = body,
                StatusCode = responsecode


            };
            await _applicationDbContext.AddAsync(log);
            await _applicationDbContext.SaveChangesAsync();
            
        }

        public async Task LogInformation(string body, string requestmethod, string requestpath, int statuscode, string exceptionmessage)
        {
            var exceptionLog = new APILog
            {
                Message = body,
                RequestMethod = requestmethod,
                RequestPath = requestpath,
                StatusCode = statuscode,
                ExceptionMessage = exceptionmessage,
                CreatedAt = DateTime.Now

            };
            await _applicationDbContext.AddAsync(exceptionLog);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
