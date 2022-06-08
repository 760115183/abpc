namespace Lis.PiYanSuoReport.Application.Settings
{
    /// <summary>
    /// 设置提供类
    /// </summary>
    public interface ISettingProvider
    {
        /// <summary>
        /// 获取用户Token密钥
        /// </summary>
        /// <returns></returns>
        string GetUserTokenSecret();

        /// <summary>
        /// 获取用户Token过期时间
        /// </summary>
        /// <returns></returns>
        int GetUserTokenExpiration();

        /// <summary>
        /// 获取用户Token刷新时间
        /// </summary>
        /// <returns></returns>
        int GetUserTokenRefreshTime();

        /// <summary>
        /// 获取开放Token密钥
        /// </summary>
        /// <returns></returns>
        string GetOpenTokenSecret();

        /// <summary>
        /// 获取开放Token过期时间
        /// </summary>
        /// <returns></returns>
        int GetOpenTokenExpiration();

        /// <summary>
        /// 获取开放Token刷新时间
        /// </summary>
        /// <returns></returns>
        int GetOpenTokenRefreshTime();

        /// <summary>
        /// 允许字典数据不对照
        /// 说明: 如果开启允许不对照, 在进行标本上传或下载时, 如果机构没有项目对照, 则不做限制
        /// </summary>
        /// <returns></returns>
        bool GetAllowNotMapping();
    }
}
