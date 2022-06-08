using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using Lis.PiYanSuoReport.Application.BaoGao.Dto;
using Lis.PiYanSuoReport.Core.BaoGao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lis.PiYanSuoReport.Application.GaoGao
{
    public class BaoGaoAppService : ApplicationService, IBaoGaoAppService
    {
        private readonly IRepository<ViewReport,string> _viewReportRepository;

        public BaoGaoAppService(
                IRepository<ViewReport, string> viewReportRepository
           )
        {
            _viewReportRepository = viewReportRepository;
        }

        /// <summary>
        /// 查询检验报告
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<QueryYangBenXXOutput>> QueryBaoGao(QueryBaoGaoInput input)
        {
            var output = new List<QueryYangBenXXOutput>();
            var dateRange = BuildQueryTime(input.DateType);

            var datas = await _viewReportRepository
                 .GetAll()
                 .Where(p => p.SFZH == input.ZhengJianHao
                    && p.PatName == input.UserName
                    && p.ReportDt >= dateRange.Start
                    && p.ReportDt <= dateRange.End)
                 .ToListAsync();

            var group = datas.GroupBy(p => p.ReportDt.Value.Date);
            foreach (var item in group)
            {
                var list = new List<QueryYangBenXXDTO>();
                var itemList = item.ToList();
                itemList.ForEach(model =>
                {
                    var dtoItem = model.MapTo<QueryYangBenXXDTO>();
                    list.Add(dtoItem);
                });
                output.Add(new QueryYangBenXXOutput
                {
                    DateStr = item.Key.ToString("MM月DD天"),
                    Items = list
                });
            }
            return output;
        }

        /// <summary>
        /// 查询检验报告详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string QueryBaoGaoDetails(QueryBaoGaoDetailsInput input)
        {
            try
            {
                var base64String = string.Empty;

                using (var stream = new FileStream(input.PdfPath, FileMode.Open))
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    stream.Close();
                    base64String = Convert.ToBase64String(bytes);
                }

                return base64String;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                throw new UserFriendlyException("文件下载失败");
            }
        }

        /// <summary>
        /// 病人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PatientInfoDto> QueryPatientInfo(QueryPatientInfoInput input)
        {
            PatientInfoDto data = await _viewReportRepository
                    .GetAll()
                     .Where(p => p.SFZH == input.ZhengJianHao && p.PatName == input.UserName)
                     .Select(p => new PatientInfoDto
                     {
                         OutPatientID = p.OutPatientID,
                         PatName = p.PatName,
                         SFZH = p.SFZH,
                     })
                     .FirstOrDefaultAsync();
            
            if (data == null)
            {
                return new PatientInfoDto
                {
                    NotFound = true,
                };
            }
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateType"></param>
        private DateRange BuildQueryTime(QueryDateType dateType)
        {
            var now = DateTime.Now;

            var dateRange = new DateRange { End = now };

            switch (dateType)
            {
                case QueryDateType.OneWeek:
                    dateRange.Start = now.AddDays(-7).Date;
                    break;
                case QueryDateType.OneMonth:
                    dateRange.Start = now.AddMonths(-1).Date;
                    break;
                case QueryDateType.ThreeMonth:
                    dateRange.Start = now.AddMonths(-3).Date;
                    break;
                case QueryDateType.SixMonth:
                    dateRange.Start = now.AddMonths(-6).Date;
                    break;
                case QueryDateType.OneYear:
                    dateRange.Start = now.AddYears(-1).Date;
                    break;
                default:
                    throw new UserFriendlyException("查询时间不合法");

            }

            return dateRange;
        }

        private class DateRange
        {
            public DateTime Start { get; set; }

            public DateTime End { get; set; }
        }
    }
}
