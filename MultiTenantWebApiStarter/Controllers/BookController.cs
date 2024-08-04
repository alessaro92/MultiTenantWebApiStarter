using Microsoft.AspNetCore.Mvc;
using MultiTenantWebApiStarter.Entities;
using MultiTenantWebApiStarter.Helpers;

namespace MultiTenantWebApiStarter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BookController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            string tenant = this.HttpContext.Request.Headers["tenant"].SingleOrDefault();

            string tenantConnectionString = _configuration.GetConnectionString(tenant);

            using NHibernate.ISession session = NHibernateHelper.GetSession(tenantConnectionString);
            return session.Query<Book>().ToList();
        }
    }
}
