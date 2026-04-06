using ExternalClients;
using Infrastructure.EF;
using Infrastructure.Repositories.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories.Abstractions;
using System;
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
                    .InstallRepositories()
                    .AddHttpClient<IDataCollectionService, CardDataCollectorClient>(client =>
                    {
                        client.BaseAddress = new Uri(configuration["ExternalApiSettings:ScrapApiUrl"]);
                        client.Timeout = TimeSpan.FromSeconds(30);
                    }); ;
            return services;
        }
        
        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IShopService, ShopService>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IReportProductService, ReportProductService>()
                .AddTransient<IDataCollectionService, CardDataCollectorClient>();
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