using Abp.Auditing;
using Abp.Authorization;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using Lis.PiYanSuoReport.Application.BaoGao.Dto;
using Lis.PiYanSuoReport.Application.GaoGao;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LXG.WebApi.Controllers
{
    /// <summary>
    /// 检验报告API控制器
    /// </summary>
    [DisableAuditing]
    [RoutePrefix("api/services/app/baoGao")]
    public class BaoGaoController : AbpApiController
    {
        private readonly IBaoGaoAppService _baogaoAppService;

        /// <summary>
        /// 
        /// </summary>       
        public BaoGaoController(IBaoGaoAppService baogaoAppService)
        {
            _baogaoAppService = baogaoAppService;
        }

        /// <summary>
        /// 查询检验报告
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryBaoGao")]
        public async Task<AjaxResponse<List<QueryYangBenXXOutput>>> QueryBaoGao(QueryBaoGaoInput input)
        {
            var result = await _baogaoAppService.QueryBaoGao(input);

            return new AjaxResponse<List<QueryYangBenXXOutput>>(result);
        }

        /// <summary>
        /// 查询病人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPatientInfo")]
        public async Task<AjaxResponse<PatientInfoDto>> QueryPatientInfo(QueryPatientInfoInput input)
        {
            var result = await _baogaoAppService.QueryPatientInfo(input);

            return new AjaxResponse<PatientInfoDto>(result);
        }

        /// <summary>
        /// 查询检验报告详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryBaoGaoDetails")]
        public AjaxResponse<string> QueryBaoGaoDetails([FromBody] QueryBaoGaoDetailsInput input)
        {
            input.PdfPath = HttpUtility.UrlDecode(input.PdfPath);
            var result = _baogaoAppService.QueryBaoGaoDetails(input);

            return new AjaxResponse<string>(result);
        }
    }
}
