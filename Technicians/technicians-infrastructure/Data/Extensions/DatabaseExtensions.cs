using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace technicians_infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        //TODO - Get logger service from the ServiceProvider

        if (env.IsDevelopment() || env.EnvironmentName == "Staging")
        {
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                //logger.LogInformation("Running DB migrations for environment: {Env}", env.EnvironmentName);

                await context.Database.MigrateAsync();
                // logger.LogInformation("Database migration completed.");
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "An error occurred while migrating the database.");
                throw;
            }
        }
        else
        {
            //logger.LogInformation("Skipping DB migration in {Env} environment.", env.EnvironmentName);
        }
    }
}
