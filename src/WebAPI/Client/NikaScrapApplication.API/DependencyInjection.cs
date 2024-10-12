using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Services;
using NikaScrapApp.Infrastructure.Repositories;
using NikaScrapApplication.API.Services;

namespace NikaScrapApplication.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnection"); 
            string secretKey = configuration.GetSection("SecretKey").Value;

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddTransient<IAuthRepository>(provider => new AuthRepository(connectionString));
            services.AddTransient<IMasterDataRepository>(provider => new MasterDataRepository(connectionString));
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IMasterDataService, MasterDataService>();
            return services;
        }
    }
}
