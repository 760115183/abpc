using Abp.Application.Services;
using Abp.Web.Models;
using Lis.PiYanSuoReport.Application.BaoGao.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lis.PiYanSuoReport.Application.GaoGao
{
    public interface IBaoGaoAppService : IApplicationService
    {
        /// <summary>
        /// 查询病人信息
        /// </summary>
        /// <returns></returns>
        Task<PatientInfoDto> QueryPatientInfo(QueryPatientInfoInput input);

        /// <summary>
        /// 查询检验报告
        /// </summary>
        /// <returns></returns>
        Task<List<QueryYangBenXXOutput>> QueryBaoGao(QueryBaoGaoInput input);


        /// <summary>
        /// 报告详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string QueryBaoGaoDetails(QueryBaoGaoDetailsInput input);

    }
}
