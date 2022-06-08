using Newtonsoft.Json;
using StackExchange.Profiling;
using System.Web.Http.Filters;

namespace Lis.PiYanSuoReport.WebApi.MiniProfilers
{
    public class WebApiProfilingActionFilter : ActionFilterAttribute
    {
        public const string MiniProfilerResultsHeaderName = "X-MiniProfiler-Ids";

        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            var MiniProfilerJson = JsonConvert.SerializeObject(new[] { MiniProfiler.Current.Id });

            if(filterContext.Response != null)
            {
                filterContext.Response.Content.Headers.Add(MiniProfilerResultsHeaderName, MiniProfilerJson);
            }            
        }
    }
}
