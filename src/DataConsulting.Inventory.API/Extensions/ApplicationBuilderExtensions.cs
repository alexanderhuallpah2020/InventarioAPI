using DataConsulting.Inventory.API.Middleware;
using DataConsulting.Inventory.Persistence;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataConsulting.Inventory.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static async void ApplyMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<ApplicationDbContext>();
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Error en migracion");
                }
            }
        }

        public static IServiceCollection AddCustomExceptionHandling(this IServiceCollection services)
        {
            services.AddProblemDetails(o =>
            {
                o.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                    context.ProblemDetails.Extensions.Add("requestId", context.HttpContext.TraceIdentifier);

                    Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                    context.ProblemDetails.Extensions.Add("traceId", activity?.Id);
                };
            });

            services.AddExceptionHandler<GlobalExceptionHandler>();

            return services;
        }
    }
}
