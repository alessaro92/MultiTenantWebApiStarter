using Microsoft.OpenApi.Models;
using MultiTenantWebApiStarter.Tenant;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MultiTenantWebApiStarter.Swagger
{
    public class TenantHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = HttpHeaderTenantResolver.TenantHeaderName,
                In = ParameterLocation.Header,
                Required = true
            });
        }
    }
}
