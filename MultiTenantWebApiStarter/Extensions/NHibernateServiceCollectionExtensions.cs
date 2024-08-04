using MultiTenantWebApiStarter.Helpers;
using MultiTenantWebApiStarter.Manager;
using MultiTenantWebApiStarter.Tenant;
using NHibernate;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NHibernateServiceCollectionExtensions
    {
        public static IServiceCollection AddNHibernate(
             this IServiceCollection services)
        {
            services.AddSingleton<ISessionFactoryManager, SessionFactoryManager>();
            services.AddScoped(sp =>
            {
                var sessionFactoryManager = sp.GetRequiredService<ISessionFactoryManager>();
                ISessionFactory sessionFactory = sessionFactoryManager.GetSessionFactory();
                NHibernate.ISession session = sessionFactory.OpenSession();
                return session;
            });

            return services;
        }
    }
}