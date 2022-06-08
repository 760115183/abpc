using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Json;
using Abp.Modules;
using Abp.WebApi;
using Lis.PiYanSuoReport.WebApi.Authentication;
using Lis.PiYanSuoReport.WebApi.MiniProfilers;
using Lis.PiYanSuoReport.WebApi.Swagger;
using Swashbuckle.Application;
using Swashbuckle.Swagger;

namespace Lis.PiYanSuoReport
{
    [DependsOn(typeof(AbpWebApiModule), typeof(PiYanSuoReportApplicationModule))]
    public class PiYanSuoReportWebApiModule : AbpModule
    {
        private const string SERVICE_PREFIX = "app";
        private const string COMMENTS_FILE_NAME = "bin\\Lis.PiYanSuoReport.Web.xml";

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(PiYanSuoReportApplicationModule).Assembly, SERVICE_PREFIX)
                .Build();
            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new WebApiProfilingActionFilter());
            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(IocManager.Resolve<JWTAuthenticationFilter>());
            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(IocManager.Resolve<JWTRefreshTokenFilter>());

            UseSwaggerUi();
        }


        private void UseSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
            .EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", $"接口文档");

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                //将注释的XML文档添加到SwaggerUI中
                c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GetXmlCommentsFile()));

                c.OperationFilter<GenerateSwaggerOperationParameterFilter>();

                c.DocumentFilter<HiddenApiFilter>();
                c.DocumentFilter<InjectMiniProfiler>();

                SetSwaggerDateTimeExample(c);
            })
            .EnableSwaggerUi(c =>
            {

                string resourceName = this.GetType().Assembly.FullName.Substring(0, this.GetType().Assembly.FullName.IndexOf(",")) + ".MiniProfilers.SwaggerUiCustomization.js";
                c.InjectJavaScript(this.GetType().Assembly, resourceName);
            });
        }

        /// <summary>
        /// 获取当前程序集注释文档
        /// </summary>
        /// <returns></returns>
        private string GetXmlCommentsFile()
        {
            return COMMENTS_FILE_NAME;
        }

        /// <summary>
        /// 设置日期时间格式
        /// </summary>
        private void SetDateTimeFormat()
        {
            var converters = Configuration.Modules.AbpWebApi().HttpConfiguration.Formatters.JsonFormatter.SerializerSettings.Converters;
            foreach (var converter in converters)
            {
                if (converter is AbpDateTimeConverter)
                {
                    var hc = converter.GetHashCode();
                    var tmpConverter = converter as AbpDateTimeConverter;
                    tmpConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                }
            }
        }

        /// <summary>
        /// 设置日期时间格式样例
        /// </summary>
        /// <param name="config"></param>
        private void SetSwaggerDateTimeExample(SwaggerDocsConfig config)
        {
            var time = TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
            var schema = new Schema { type = "DateTime", format = "yyyy-MM-dd HH:mm:ss", example = time };

            config.MapType<DateTime?>(() => schema);
            config.MapType<DateTime>(() => schema);
        }

    }
}
