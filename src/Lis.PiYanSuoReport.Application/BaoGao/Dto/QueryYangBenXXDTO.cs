using Abp.AutoMapper;
using Lis.PiYanSuoReport.Core.BaoGao;
using System;

namespace Lis.PiYanSuoReport.Application.BaoGao.Dto
{
    /// <summary>
    /// 样本信息
    /// </summary
    [AutoMapFrom(typeof(ViewReport))]
    public class QueryYangBenXXDTO
    {
        // <summary>
        /// 病案号 (病人唯一号)
        /// </summary>
        public string InpatientID { get; set; }

        /// <summary>
        /// 门诊号 （门诊就诊卡号，如住院病人可为空）
        /// </summary>
        public string OutPatientID { get; set; }

        /// <summary>
        /// 体检ID
        /// </summary>
        public string TIJIANID { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string SFZH { get; set; }

        /// <summary>
        /// 患者类型 （0 门诊 1 住院 3 急诊 4 体检）
        /// </summary>
        public int? PatType { get; set; }

        /// <summary>
        /// 报告类型 （1 检验 2 检查)
        /// </summary>
        public int? ReportType { get; set; }

        /// <summary>
        /// 检查类型 （CT,DR,CR,MR,DSA,RF,XA,DX,ES,US,GM等)
        /// </summary>
        public string Modality { get; set; }

        /// <summary>
        /// 报告唯一编号 （通过唯一编号找到报告）
        /// </summary>
        public string ReportSeq { get; set; }

        /// <summary>
        /// 报告日期 （yyyy-mm-dd hh24:mi:ss）
        /// </summary>
        public DateTime? ReportDt { get; set; }

        /// <summary>
        /// 审核日期 （yyyy-mm-dd hh24:mi:ss）
        /// </summary>
        public DateTime? VerifyDt { get; set; }

        /// <summary>
        /// 报告状态 （0 已开单 1 已检查 2 已报告 3 已审核 4 其他状态）
        /// </summary>
        public int? OrderStatus { get; set; }

        /// <summary>
        /// 是否已经打印
        /// </summary>
        public int? IsPrint { get; set; }

        /// <summary>
        /// 最后修改日期 （yyyy-mm-dd hh24:mi:ss）
        /// </summary>
        public DateTime? EditDt { get; set; }

        /// <summary>
        /// 报告备注提醒1
        /// </summary>
        public string ReportBeiZhu1 { get; set; }

        /// <summary>
        /// 报告备注提醒2
        /// </summary>
        public string ReportBeiZhu2 { get; set; }
    }
}
