using Microsoft.AspNetCore.Mvc;
using MultiTenantWebApiStarter.Entities;
using MultiTenantWebApiStarter.Helpers;

namespace MultiTenantWebApiStarter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            using NHibernate.ISession session = NHibernateHelper.GetSession();
            return session.Query<Book>().ToList();
        }
    }
}
