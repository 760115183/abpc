using Abp.Dependency;
using Abp.Extensions;
using Lis.PiYanSuoReport.Application.Authentication;
using Lis.PiYanSuoReport.Application.Settings;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Lis.PiYanSuoReport.WebApi.Authentication
{
    /// <summary>
    /// token刷新过滤器
    /// </summary>
    public class JWTRefreshTokenFilter : ActionFilterAttribute, ITransientDependency
    {
        private readonly ISettingProvider _settingProvider;
        private readonly JWTHelper _jwtHelper;

        public JWTRefreshTokenFilter(ISettingProvider settingProvider, JWTHelper jwtHelper)
        {
            _settingProvider = settingProvider;
            _jwtHelper = jwtHelper;
        }

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            string token = string.Empty;
            if (filterContext.Request.Headers.Authorization != null)
            {
                token = filterContext.Request.Headers.Authorization.Parameter;
            }

            object value;
            if(filterContext.ActionArguments.TryGetValue("JWT_INFO", out value))
            {               
                var newToken = _jwtHelper.RefreshToken(value as JWTInfo, _settingProvider.GetUserTokenSecret(), 
                    _settingProvider.GetUserTokenExpiration(), _settingProvider.GetUserTokenRefreshTime());

                if(!newToken.IsNullOrEmpty())
                {
                    filterContext.ActionArguments.Add(WebApiConsts.NEW_TOKEN_NAME, newToken);
                }
            }             

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            object value;
            if (!actionExecutedContext.ActionContext.ActionArguments.TryGetValue(WebApiConsts.NEW_TOKEN_NAME, out value))
            {
                return;
            }

            actionExecutedContext.Response?.Headers.Add(WebApiConsts.NEW_TOKEN_NAME, value.ToString());
        }               
    }
}
