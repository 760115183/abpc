using System;
using System.Diagnostics;
using System.Web.Http;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Lis.PiYanSuoReport.Common.Config;
using StackExchange.Profiling;

namespace Lis.PiYanSuoReport.Web
{
    public class MvcApplication : AbpWebApplication<PiYanSuoReportWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                 f => f.UseAbpLog4Net().WithConfig("log4net.config")
             );
            
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();

            base.Application_Start(sender, e);
        }


        /// <summary>
        /// 默认重定向
        /// </summary>
        protected override void Application_BeginRequest(object sender, EventArgs e)
        {
            MiniProfiler.Start();

            //如果根目录下没有index.html文件,则会重定下到如下地址
            if (Context.Request.FilePath == "/")
            {
                var defaultUrl = WebConfigHelper.GetValue("App.DefaultUrl");

                Context.RewritePath(defaultUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Application_EndRequest(object sender, EventArgs e)
        {
            MiniProfiler.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Application_Error(object sender, EventArgs e)
        {
            base.Application_Error(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Application_End(object sender, EventArgs e)
        {
            EventLog.WriteEntry("Global.MvcApplication", "Application_End Raised");

            base.Application_End(sender, e);
        }
    }
}
