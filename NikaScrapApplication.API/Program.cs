using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Services;
using NikaScrapApp.Infrastructure.Repositories;
using NikaScrapApplication.API.Middlewares;
using NikaScrapApplication.API.Services;
using NLog;
using NLog.Web;
using System.Text;

namespace NikaScrapApplication.API
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
                //builder.Services.AddSwaggerGen();
                // Register the Swagger generator, defining 1 or more Swagger documents
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Digital Kabadi",
                        Description = "Digital Kabadi API",
                        TermsOfService = new Uri("https://pragimtech.com"),
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


                // Configure Dependency Injection.
                //builder.Services.ConfigureDependencyInjection();
                
                string secretKey = builder.Configuration.GetSection("SecretKey").Value;

                builder.Services.AddTransient<IAuthRepository>(provider => new AuthRepository(connectionString));
                builder.Services.AddTransient<IMasterDataRepository>(provider => new MasterDataRepository(connectionString));
                //builder.Services.AddScoped<IAuthenticateService, AuthenticateService>(); 
                builder.Services.AddTransient<IAuthenticateService>(provider => new AuthenticateService(secretKey, new AuthRepository(connectionString))); 
                builder.Services.AddScoped<IMasterDataService, MasterDataService>();
                builder.Services.AddScoped<IUserService, UserService>();
                builder.Services.AddTransient<IUserRepository>(provider => new UserRepository(connectionString));
                builder.Services.AddScoped<ISchedulePickupService, SchedulePickupService>(); 
                builder.Services.AddTransient<ISchedulePickupRepositary>(provider => new SchedulePickupRepository(connectionString));
                 
                //builder.Services.AddTransient<AuthService>(provider => new AuthService(secretKey)); 
                builder.Services
                .AddAuthentication(x => {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x => {
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                });

                builder.Services.AddAuthentication();
              var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

                //app.MapPost("/authenticate",(UserCredential userCredential, AuthService authService)=> authService.GenrateToken(userCredential));
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
