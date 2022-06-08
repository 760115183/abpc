using Abp.Owin;
using Lis.PiYanSuoReport.Web.App_Start;
using Lis.PiYanSuoReport.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Threading.Tasks;
using System.Web.Cors;

[assembly: OwinStartup(typeof(Startup))]


namespace Lis.PiYanSuoReport.Web.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            app.UseAbp();

            UseCors(app);

        }

        private void UseCors(IAppBuilder app)
        {
            var policy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                AllowAnyOrigin = true,
                SupportsCredentials = true
            };

            //添加自定义导出头
            policy.ExposedHeaders.Add(WebApiConsts.NEW_TOKEN_NAME);
            policy.ExposedHeaders.Add("Content-Disposition");

            app.UseCors(new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(policy)
                }
            });
        }
    }
}