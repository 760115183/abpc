namespace Lis.PiYanSuoReport.Application.Authentication
{
    /// <summary>
    /// JWT信息
    /// </summary>
    public class JWTInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId
        {
            get; set;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get; set;
        }

        /// <summary>
        /// 过期时间（秒）
        /// </summary>
        public long Expire
        {
            get; set;
        }
    }
}
