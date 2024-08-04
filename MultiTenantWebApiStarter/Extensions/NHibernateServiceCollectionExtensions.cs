using MultiTenantWebApiStarter.Helpers;
using MultiTenantWebApiStarter.Tenant;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NHibernateServiceCollectionExtensions
    {
        public static IServiceCollection AddNHibernate(
             this IServiceCollection services)
        {
            services.AddScoped(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var tenantResolver = sp.GetRequiredService<ITenantResolver>();

                string tenant = tenantResolver.GetTenant();

                string tenantConnectionString = configuration.GetConnectionString(tenant);

                NHibernate.ISession session = NHibernateHelper.GetSession(tenantConnectionString);

                return session;
            });

            return services;
        }
    }
}