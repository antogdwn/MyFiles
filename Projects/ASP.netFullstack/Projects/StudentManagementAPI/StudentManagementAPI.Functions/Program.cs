using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentManagementAPI.Data;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context,services) =>
    {
        var connectionstring = context.Configuration.GetConnectionString("StudentDb") ?? throw new InvalidProgramException("Student Db connection string is not configured");
        services.AddDbContext<StudentManagementAPI.Data.AppDbContext>(options => options.UseSqlServer(connectionstring));
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
