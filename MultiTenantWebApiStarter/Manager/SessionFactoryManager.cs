using MultiTenantWebApiStarter.Helpers;
using MultiTenantWebApiStarter.Tenant;
using NHibernate;
using System.Collections.Concurrent;

namespace MultiTenantWebApiStarter.Manager
{
    public class SessionFactoryManager : ISessionFactoryManager
    {
        private readonly IConfiguration _configuration;
        private readonly ITenantResolver _tenantResolver;

        private IDictionary<string, ISessionFactory> _sessionFactories;

        public SessionFactoryManager(IConfiguration configuration, ITenantResolver tenantResolver)
        {
            this._configuration = configuration;
            this._tenantResolver = tenantResolver;

            this._sessionFactories = new ConcurrentDictionary<string, ISessionFactory>();
        }

        public ISessionFactory GetSessionFactory()
        {
            string tenant = this._tenantResolver.GetTenant();

            if (!this._sessionFactories.ContainsKey(tenant))
            {
                string tenantConnectionString = this._configuration.GetConnectionString(tenant);

                ISessionFactory sessionFactory = NHibernateHelper.GetSessionFactory(tenantConnectionString);

                this._sessionFactories.TryAdd(tenant, sessionFactory);
            }

            return this._sessionFactories[tenant];
        }
    }
}
