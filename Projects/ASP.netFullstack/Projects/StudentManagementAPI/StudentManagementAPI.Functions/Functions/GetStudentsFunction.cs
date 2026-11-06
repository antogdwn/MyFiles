using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Functions.Functions;

public sealed class GetStudentsFunction
{
    private readonly AppDbContext _context;
    private readonly ILogger<GetStudentsFunction> _logger;

    public GetStudentsFunction(
        AppDbContext context,
        ILogger<GetStudentsFunction> logger)
    {
        _context = context;
        _logger = logger;
    }

    [Function("GetStudents")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(
            AuthorizationLevel.Anonymous,
            "get",
            Route = "students")] HttpRequestData request,
        CancellationToken cancellationToken)
    {
        var query = System.Web.HttpUtility.ParseQueryString(request.Url.Query);

        var pageNumber = int.TryParse(query["pageNumber"], out var parsedPageNumber)
            ? parsedPageNumber
            : 1;

        var pageSize = int.TryParse(query["pageSize"], out var parsedPageSize)
            ? parsedPageSize
            : 10;

        if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
        {
            var invalidResponse = request.CreateResponse(HttpStatusCode.BadRequest);

            await invalidResponse.WriteAsJsonAsync(new
            {
                message = "pageNumber must be at least 1 and pageSize must be between 1 and 100."
            }, cancellationToken);

            return invalidResponse;
        }

        _logger.LogInformation(
            "Reading students. PageNumber: {PageNumber}, PageSize: {PageSize}",
            pageNumber,
            pageSize);

        var students = await _context.Students
            .AsNoTracking()
            .OrderBy(student => student.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(
            students,
            cancellationToken);

        return response;
    }
}