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
        private readonly NHibernate.ISession _session;

        public BookController(NHibernate.ISession session)
        {
            this._session = session;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return this._session.Query<Book>().ToList();
        }
    }
}
