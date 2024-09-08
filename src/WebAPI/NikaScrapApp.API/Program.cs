using NLog;
using NLog.Web;
using System.Data.Common;

namespace NikaScrapApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.LogManager
                .Setup()
                .LoadConfigurationFromAppSettings()
                .GetCurrentClassLogger();

            try
            {

             string currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
             IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, reloadOnChange: true);

            if (currentEnvironment?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
            {
                configBuilder.AddJsonFile($"appsettings.{currentEnvironment}.json", optional: false);
            }

                var builder = WebApplication.CreateBuilder(args);

            // Clear default logging providers
            builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                builder.Host.UseNLog();

            // Add services to the container.

            builder.Services.AddControllers();
             
           string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                // Configure Dependency Injection.
                //builder.Services.ConfigureDependencyInjection(Configuration);

                // Add Swagger generator services to the services container.
                // This will be used to produce the Swagger document (OpenAPI spec) and the Swagger UI
                builder.Services.AddEndpointsApiExplorer();

                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                // Configure the HTTP request pipeline.

                app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            }
            catch (Exception exception)
            {
                // NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }
    }
}
