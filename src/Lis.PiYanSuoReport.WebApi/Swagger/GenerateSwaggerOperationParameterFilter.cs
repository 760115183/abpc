using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Lis.PiYanSuoReport.WebApi.Swagger
{
    /// <summary>
    /// 用于生成Swagger中请求API时增加请求参数
    /// </summary>
    public class GenerateSwaggerOperationParameterFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            if (!allowAnonymous)
            {
                operation.parameters.Add(new Parameter { name = "Authorization", @in = "header", description = "登录后返回的token", required = true, type = "string" });
            }
        }
    }
}
