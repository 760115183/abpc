using Lis.PiYanSuoReport.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace Lis.PiYanSuoReport.Application.BaoGao.Dto
{
    /// <summary>
    /// 查询报告请求参数
    /// </summary>
    public class QueryBaoGaoInput : PagedAndSortedResultRequest
    {
        /// <summary>
        /// 查询时间类型
        /// </summary>
        public QueryDateType DateType
        {
            get; set;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string UserName
        {
            get; set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "请输入身份证号")]
        public string ZhengJianHao
        {
            get; set;
        }
    }

    /// <summary>
    /// 查询时间类型
    /// </summary>
    public enum QueryDateType
    {
        /// <summary>
        /// 最近一周
        /// </summary>
        OneWeek = 0,

        /// <summary>
        /// 最近一个月
        /// </summary>
        OneMonth = 1,

        /// <summary>
        /// 最近三个月
        /// </summary>
        ThreeMonth = 2,

        /// <summary>
        /// 最近半年
        /// </summary>
        SixMonth = 3,

        /// <summary>
        /// 最近一年
        /// </summary>
        OneYear = 4
    }
}
