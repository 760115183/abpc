using Lis.PiYanSuoReport.Core.Common.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lis.PiYanSuoReport.Core.BaoGao
{
    [Table("VIEWREPORT")]
    public class ViewReport : AppEntity<string>
    {
        /// <summary>
        /// 病案号 (病人唯一号)
        /// </summary>
        [Column("INPATIENTID")]
        public string InpatientID { get; set; }

        /// <summary>
        /// 门诊号 （门诊就诊卡号，如住院病人可为空）
        /// </summary>
        [Column("OUTPATIENTID")]
        public string OutPatientID { get; set; }

        /// <summary>
        /// 体检ID
        /// </summary>
        [Column("TIJIANID")]
        public string TIJIANID { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        [Column("PATNAME")]
        public string PatName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Column("SFZH")]
        public string SFZH { get; set; }

        /// <summary>
        /// 患者类型 （0 门诊 1 住院 3 急诊 4 体检）
        /// </summary>
        [Column("PATTYPE")]
        public int? PatType { get; set; }

        /// <summary>
        /// 报告类型 （1 检验 2 检查)
        /// </summary>
        [Column("REPORTTYPE")]
        public int? ReportType { get; set; }

        /// <summary>
        /// 检查类型 （CT,DR,CR,MR,DSA,RF,XA,DX,ES,US,GM等)
        /// </summary>
        [Key]
        [Column("MODALITY", Order = 1)]
        public string Modality { get; set; }

        /// <summary>
        /// 报告唯一编号 （通过唯一编号找到报告）
        /// </summary>
        [Key]
        [Column("REPORTSEQ", Order = 2)]
        public string ReportSeq { get; set; }

        /// <summary>
        /// 报告日期 （yyyy-mm-dd hh24:mi:ss）
        /// </summary>
        [Column("REPORTDT")]
        public DateTime? ReportDt { get; set; }

        /// <summary>
        /// 审核日期 （yyyy-mm-dd hh24:mi:ss）
        /// </summary>
        [Column("VERIFYDT")]
        public DateTime? VerifyDt { get; set; }

        /// <summary>
        /// 报告状态 （0 已开单 1 已检查 2 已报告 3 已审核 4 其他状态）
        /// </summary>
        [Column("ORDERSTATUS")]
        public int? OrderStatus { get; set; }

        /// <summary>
        /// PDF路径
        /// </summary>
        [Key]
        [Column("PDFPATH", Order = 3)]
        public string PdfPath { get; set; }

        /// <summary>
        /// PDF文件名,并提供报告命名规则）
        /// </summary>
        [Column("PDFNAME")]
        public string PdfName { get; set; }

        /// <summary>
        /// 是否已经打印
        /// </summary>
        [Column("ISPRINT")]
        public int? IsPrint { get; set; }

        /// <summary>
        /// 最后修改日期 （yyyy-mm-dd hh24:mi:ss）
        /// </summary>
        [Column("EDITDT")]
        public DateTime? EditDt { get; set; }

        /// <summary>
        /// 报告备注提醒1
        /// </summary>
        [Column("REPORTBEIZHU1")]
        public string ReportBeiZhu1 { get; set; }

        /// <summary>
        /// 报告备注提醒2
        /// </summary>
        [Column("REPORTBEIZHU2")]
        public string ReportBeiZhu2 { get; set; }
    }
}
