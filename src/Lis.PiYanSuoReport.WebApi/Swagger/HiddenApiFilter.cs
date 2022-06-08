using Abp.WebApi.Controllers.Dynamic.Scripting;
using Abp.WebApi.Runtime.Caching;
using Swashbuckle.Swagger;
using System;
using System.Linq;
using System.Web.Http.Description;

namespace Lis.PiYanSuoReport.WebApi.Swagger
{
    /// <summary>
    /// 指定隐藏部分接口
    /// </summary>
    public class HiddenApiFilter : IDocumentFilter
    {
        private readonly Type[] filterControllers = new Type[]
        {
            typeof(AbpCacheController),
            typeof(AbpServiceProxiesController),
            typeof(TypeScriptController)
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiExplorer"></param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            foreach (ApiDescription apiDescription in apiExplorer.ApiDescriptions)
            {
                if (filterControllers.Contains(apiDescription.ActionDescriptor.ControllerDescriptor.ControllerType))
                {
                    string key = "/" + apiDescription.RelativePath;
                    if (key.Contains("?"))
                    {
                        int idx = key.IndexOf("?", System.StringComparison.Ordinal);
                        key = key.Substring(0, idx);
                    }
                    swaggerDoc.paths.Remove(key);
                }
            }
        }
    }
}