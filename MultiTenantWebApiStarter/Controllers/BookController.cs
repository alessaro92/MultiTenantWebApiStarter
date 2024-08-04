using Microsoft.AspNetCore.Mvc;
using MultiTenantWebApiStarter.Entities;
using MultiTenantWebApiStarter.Helpers;
using MultiTenantWebApiStarter.Tenant;

namespace MultiTenantWebApiStarter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITenantResolver _tenantResolver;

        public BookController(IConfiguration configuration, ITenantResolver tenantResolver)
        {
            this._configuration = configuration;
            this._tenantResolver = tenantResolver;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            string tenant = this._tenantResolver.GetTenant();

            string tenantConnectionString = _configuration.GetConnectionString(tenant);

            using NHibernate.ISession session = NHibernateHelper.GetSession(tenantConnectionString);
            return session.Query<Book>().ToList();
        }
    }
}
