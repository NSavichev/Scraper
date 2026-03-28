using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure.EF
{
    public static class EFInstaller
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<DatabaseContext>(optionsBuilder
                => optionsBuilder
                    .UseLazyLoadingProxies() // lazy loading
                                             //.UseNpgsql(connectionString));
                    .UseSqlite(connectionString));
            //.UseSqlServer(connectionString));

            #region health checks

            services.AddHealthChecks()
                .AddDbContextCheck<DatabaseContext>(
                    tags: new[] { "db_ef_healthcheck" },
                    customTestQuery: async (context, token) =>
                    {
                        return await context.Products.AnyAsync(token);
                    });

            #endregion
            return services;
        }
    }
}
