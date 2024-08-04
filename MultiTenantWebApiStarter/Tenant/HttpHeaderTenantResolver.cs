namespace MultiTenantWebApiStarter.Tenant
{
    public class HttpHeaderTenantResolver : ITenantResolver
    {
        public const string TenantHeaderName = "tenant";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpHeaderTenantResolver(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetTenant()
        {
            return this._httpContextAccessor.HttpContext.Request.Headers[TenantHeaderName].SingleOrDefault();

        }
    }
}
