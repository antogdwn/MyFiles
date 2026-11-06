using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace HONOrdersApp.Filters
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private Stopwatch _watch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // TODO:
            // - Start a Stopwatch before the action executes.
            // - Store the instance in a private field.
            // - Use high-resolution timing.
            throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // TODO:
            // - Stop the Stopwatch after action execution.
            // - Add a response header named "Server-Timing".
            // - Format should be:
            //      app;dur=<executionTimeInMilliseconds>
            // - Do NOT throw if Stopwatch is null.
            // - Ensure header is written correctly to HttpContext.Response.Headers.
                throw new NotImplementedException();
        }
    }
}
