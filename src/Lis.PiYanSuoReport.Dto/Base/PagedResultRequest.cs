namespace Lis.PiYanSuoReport.Dto.Base
{
    /// <summary>
    /// 分页请求参数
    /// </summary>
    public class PagedResultRequest
    {
        /// <summary>
        /// 路过记录数
        /// </summary>
        public int SkipCount
        {
            get; set;
        }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int MaxResultCount
        {
            get; set;
        }
    }
}
