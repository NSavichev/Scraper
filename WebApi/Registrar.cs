using Infrastructure.EF;
using Infrastructure.Repositories.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories.Abstractions;
using WebApi.Settings;

namespace WebApi
{
    /// <summary>
    /// Регистратор сервиса.
    /// </summary>
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                    .AddSingleton((IConfigurationRoot)configuration)
                    .InstallServices()
                    .ConfigureContext(applicationSettings.ConnectionString)
                    .InstallRepositories();
            return services;
        }
        
        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IShopService, ShopService>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IReportProductService, ReportProductService>();
            return serviceCollection;
        }
        
        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IShopRepository, ShopRepository>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IReportProductRepository, ReportProductRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }
    }
}