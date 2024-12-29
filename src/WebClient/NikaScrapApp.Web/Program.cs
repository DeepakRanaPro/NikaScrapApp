using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Services;
using DigitalKabadiApp.Infrastructure.Repositories;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Utility;
using NikaScrapApp.Web.Utility.CustomFilters;
using NLog;
using NLog.Web;
namespace NikaScrapApp.Web
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
                var builder = WebApplication.CreateBuilder(args);

                // Clear default logging providers
                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                builder.Host.UseNLog();

                // Add services to the container.
                builder.Services.AddControllersWithViews(options =>
                {
                    options.Filters.Add<GlobalExceptionFilter>();
                });


                // Add services to the container.
                builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            
                builder.Services.AddControllersWithViews();

                // Add services to the container
                builder.Services.AddControllersWithViews();
                builder.Services.AddDistributedMemoryCache();
                builder.Services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(30);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });
                builder.Services.AddHttpContextAccessor();

                string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                builder.Services.AddTransient<IAuthRepository>(provider => new AuthRepository(connectionString));
                builder.Services.AddScoped<IAuthService, AuthService>();
                builder.Services.AddTransient<ICategoryRepository>(provider => new CategoryRepository(connectionString));
                builder.Services.AddScoped<ICategoryService, CategoryService>();
                builder.Services.AddTransient<IPickupRepository>(provider => new PickupRepository(connectionString));
                builder.Services.AddScoped<IPickupService, PickupService>();
                builder.Services.AddTransient<IMasterDataRepository>(provider => new MasterDataRepository(connectionString));
                builder.Services.AddScoped<IMasterDataService, MasterDataService>();
                builder.Services.AddTransient<iFeedbackRepositary>(provider => new FeedbackRepositary(connectionString));
                builder.Services.AddScoped<iFeedbackService, FeedbackService>();
                builder.Services.AddTransient<IContactUsRepositary>(provider => new ContactUsRepositary(connectionString));
                builder.Services.AddScoped<IContactUsService, ContactUsService>();
                builder.Services.AddTransient<IPickupBoyRepository>(provider => new PickupBoyRepository(connectionString));
                builder.Services.AddScoped<IPickUpBoyService, PickUpBoyService>();

                builder.Services.AddTransient<IProductRepository>(provider => new ProductRepository(connectionString));
                builder.Services.AddScoped<IProductService, ProductService>();

                builder.Services.AddTransient<IScrapPickerPaymentRepository>(provider => new ScrapPickerPaymentRepository(connectionString));
                builder.Services.AddScoped<IScrapPickerPaymentService, ScrapPickerPaymentService>();

                //

                var app = builder.Build();

                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();

                // Use session middleware
                app.UseSession();
                SessionManager.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    //app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

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