using DigitalKabadiApp.API.Middlewares;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Services;
using DigitalKabadiApp.Infrastructure.Repositories;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;

namespace DigitalKabadiApp.API
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

                string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Digital Kabadi Admin",
                        Description = "Digital Kabadi Admin API",
                        TermsOfService = new Uri("https://DigitalKabadi.com"),
                        Contact = new OpenApiContact
                        {
                            Name = "TechSimSol",
                            Email = "TechSimSol@gmail.com",
                            Url = new Uri("https://twitter.com/TechSimSol"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Digital Kabadi Open License",
                            Url = new Uri("https://DigitalKabadi.com"),
                        }
                    });
                });

                builder.Services.AddTransient<IAuthRepository>(provider => new AuthRepository(connectionString));
                builder.Services.AddScoped<IAuthService, AuthService>();
                builder.Services.AddTransient<ICategoryRepository>(provider => new CategoryRepository(connectionString));
                builder.Services.AddScoped<ICategoryService, CategoryService>();
                builder.Services.AddTransient<IPickupRepository>(provider => new PickupRepository(connectionString));
                builder.Services.AddScoped<IPickupService, PickupService>();
                builder.Services.AddTransient<IMasterDataRepository>(provider => new MasterDataRepository(connectionString));
                builder.Services.AddScoped<IMasterDataService, MasterDataService>();

                builder.Services.AddTransient<IProductRepository>(provider => new ProductRepository(connectionString));
                builder.Services.AddScoped<IProductService, ProductService>();

                builder.Services.AddTransient<ISmsRepository>(provider => new SmsRepository(connectionString));
                builder.Services.AddScoped<ISmsService, SmsService>();
                 
                var app = builder.Build();

                // Configure the HTTP request pipeline.
                //if (app.Environment.IsDevelopment())
                //{
                    app.UseSwagger();
                    app.UseSwaggerUI();
                //}

                app.UseAuthentication();
                app.UseAuthorization();

                app.UseHttpCodeAndLogMiddleware();
                app.MapControllers();

                app.UseStaticFiles(); // For the wwwroot folder

                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(
                                        Path.Combine(Directory.GetCurrentDirectory(), @"ProductImages")),
                    RequestPath = new PathString("/app-images")
                });

                app.Run();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
