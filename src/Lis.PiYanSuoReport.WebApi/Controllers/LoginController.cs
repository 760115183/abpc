using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using Lis.PiYanSuoReport.Application.Authentication;
using Lis.PiYanSuoReport.Application.BaoGao.Dto;
using Lis.PiYanSuoReport.Application.GaoGao;
using Lis.PiYanSuoReport.Application.Settings;
using Lis.PiYanSuoReport.Core.BaoGao;
using Lis.PiYanSuoReport.Login.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lis.PiYanSuoReport.Api.Controllers
{
    public class LoginController : AbpApiController
    {
        private readonly JWTHelper _jwtHelper;
        private readonly ISettingProvider _settingProvider;
        private readonly IBaoGaoAppService _baogaoAppService;
        private readonly IRepository<ViewReport, string> _viewReportRepository;

        public LoginController(JWTHelper jwtHelper, 
            ISettingProvider settingProvider,
            IBaoGaoAppService baogaoAppService,
            IRepository<ViewReport, string> viewReportRepository)
        {
            _jwtHelper = jwtHelper;
            _settingProvider = settingProvider;
            _baogaoAppService = baogaoAppService;
            _viewReportRepository = viewReportRepository;
        }

        /// <summary>
        /// 用户登录认证API
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<AjaxResponse> Authenticate(LoginModel loginModel)
        {
            var loginResult = await GetLoginResultAsync(loginModel);

            var token = this.CreateToken(loginModel);

            return new AjaxResponse(token);
        }


        private async Task<LoginModel> GetLoginResultAsync(LoginModel loginModel)
        {
            PatientInfoDto loginResult = null;
            try
            {
                loginResult = await _baogaoAppService.QueryPatientInfo(new QueryPatientInfoInput
                {
                    ZhengJianHao = loginModel.ZhengJianHao,
                    UserName = loginModel.UserName
                });
            } catch (Exception e)
            {
                
            }

            if (loginResult == null || loginResult.NotFound)
            {
                throw new UserFriendlyException("登录失败，姓名或身份证号错误");
            }
            return loginModel;
        }

        private string CreateToken(LoginModel loginResult)
        {
            var jwtInfo = new JWTInfo
            {
                UserId = loginResult.ZhengJianHao,
                UserName = loginResult.UserName,
            };

            return _jwtHelper.CreateToken(jwtInfo, _settingProvider.GetUserTokenSecret(), _settingProvider.GetUserTokenExpiration());
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("登录失败", "用户或身份证填写有误");
            }
        }
    }
}
