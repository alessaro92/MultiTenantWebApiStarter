using FluentNHibernate.Cfg;
using MultiTenantWebApiStarter.Mappings;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using Environment = NHibernate.Cfg.Environment;

namespace MultiTenantWebApiStarter.Helpers
{
    public class NHibernateHelper
    {
        public static NHibernate.ISession GetSession(string connectionString)
        {
            var nhCfg = new Configuration();
            nhCfg.SetProperty(Environment.ConnectionProvider, typeof(DriverConnectionProvider).AssemblyQualifiedName);
            nhCfg.SetProperty(Environment.Dialect, typeof(PostgreSQLDialect).AssemblyQualifiedName);
            nhCfg.SetProperty(Environment.ConnectionDriver, typeof(NpgsqlDriver).AssemblyQualifiedName);
            nhCfg.SetProperty(Environment.ConnectionString, connectionString);
            nhCfg.SetProperty(Environment.ProxyFactoryFactoryClass, typeof(DefaultProxyFactoryFactory).AssemblyQualifiedName);
            nhCfg.SetProperty(Environment.Hbm2ddlKeyWords, Hbm2DDLKeyWords.AutoQuote.ToString());
            nhCfg.SetProperty(Environment.CurrentSessionContextClass, "web");
            nhCfg.SetProperty(Environment.BatchSize, "1");

            FluentConfiguration fluentCfg = Fluently
                .Configure(nhCfg)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BookMap>())
                .Cache(c => c.UseQueryCache()
                             .ProviderClass<HashtableCacheProvider>());

            Configuration nhBuiltCfg = fluentCfg.BuildConfiguration();

            ISessionFactory sessionFactory = nhBuiltCfg.BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
