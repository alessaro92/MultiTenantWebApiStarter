using NHibernate;

namespace MultiTenantWebApiStarter.Manager
{
    public interface ISessionFactoryManager
    {
        ISessionFactory GetSessionFactory();
    }
}