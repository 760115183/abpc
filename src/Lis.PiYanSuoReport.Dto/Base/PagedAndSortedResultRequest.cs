namespace Lis.PiYanSuoReport.Dto.Base
{
    /// <summary>
    /// 分页并排序的请求
    /// </summary>
    public class PagedAndSortedResultRequest
    {
        /// <summary>
        /// 跳过记录数
        /// </summary>
        public int SkipCount
        {
            get;
            set;
        }

        /// <summary>
        /// 返回每页记录数
        /// </summary>
        public int MaxResultCount
        {
            get;
            set;
        }

        /// <summary>
        /// 排序字符 如 filed asc或field desc
        /// </summary>
        public string Sorting
        {
            get;
            set;
        }
    }
}
