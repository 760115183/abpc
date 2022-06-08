using System.ComponentModel.DataAnnotations;

namespace Lis.PiYanSuoReport.Application.BaoGao.Dto
{
    /// <summary>
    /// 查询报告详情
    /// </summary>
    public class QueryBaoGaoDetailsInput
    {
        /// <summary>
        /// pdf地址
        /// </summary>
        [Required(ErrorMessage = "pdf地址不能为空")]
        public string PdfPath { get; set; }

    }
}
