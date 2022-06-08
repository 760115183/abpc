using StackExchange.Profiling;
using Swashbuckle.Swagger;
using System.Web.Http.Description;

namespace Lis.PiYanSuoReport.WebApi.MiniProfilers
{
    public class InjectMiniProfiler : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.info.contact = new Contact()
            {
                name = MiniProfiler.RenderIncludes().ToHtmlString()
            };
        }
    }
}
