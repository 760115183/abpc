using Abp.Dependency;
using Abp.Runtime.Security;
using JWT;
using Lis.PiYanSuoReport.Application.Authentication;
using Lis.PiYanSuoReport.Application.Settings;
using Lis.PiYanSuoReport.Common.Exceptions;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Lis.PiYanSuoReport.WebApi.Authentication
{
    /// <summary>
    /// JWT身份认证过滤器
    /// </summary>
    public class JWTAuthenticationFilter : IAuthenticationFilter, ITransientDependency
    {
        private readonly ISettingProvider _settingProvider;
        private readonly JWTHelper _jwtHelper;

        public bool AllowMultiple => true;

        public JWTAuthenticationFilter(ISettingProvider settingProvider, JWTHelper jwtHelper)
        {
            _settingProvider = settingProvider;
            _jwtHelper = jwtHelper;
        }

        /// <summary>
        /// 请求先经过AuthenticateAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            //如果API的Action带有AllowAnonymousAttribute，则不进行授权验证
            if (context.ActionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return Task.FromResult(0);
            }

            string token = string.Empty;
            if(context.Request.Headers.Authorization != null)
            {
                token = context.Request.Headers.Authorization.Parameter;
            }

            JWTInfo jwtInfo = this.CheckAndParseToken(token);

            this.CreatePrincipal(context, jwtInfo);

            context.ActionContext.ActionArguments.Add("JWT_INFO", jwtInfo);

            return Task.FromResult(0);
        }

        /// <summary>
        /// 请求后经过AuthenticateAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {       
            return Task.FromResult(0);
        }

        /// <summary>
        /// 解析TOKEN
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private JWTInfo CheckAndParseToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw UserFriendlyExceptionCreator.Create(ErrorCodes.TokenNotFound, "认证失败");
            }

            try
            {
                return _jwtHelper.ParseToken(token, _settingProvider.GetUserTokenSecret());
            }
            catch (TokenExpiredException ex)
            {
                throw UserFriendlyExceptionCreator.Create(ErrorCodes.TokenExpired, "认证失败", ex);
            }
            catch (SignatureVerificationException ex)
            {
                throw UserFriendlyExceptionCreator.Create(ErrorCodes.IllegalToken, "认证失败", ex);
            }
            catch (Exception ex)
            {
                throw UserFriendlyExceptionCreator.Create(ErrorCodes.IllegalToken, "认证失败", ex);
            }
        }

        private void CreatePrincipal(HttpAuthenticationContext context, JWTInfo jwtInfo)
        {
            //只要ClaimsIdentity设置了authenticationType，authenticated就为true，后面的authority根据authenticated=true来做权限
            var identity = new ClaimsIdentity("jwt", "userId", "roles");
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, jwtInfo.UserId));
            identity.AddClaim(new Claim(ClaimTypes.Name, jwtInfo.UserName));
            // 最好是http上下文的principal和进程的currentPrincipal都设置
            context.Principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = new ClaimsPrincipal(identity);            
        }
    }
}
