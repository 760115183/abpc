namespace Lis.PiYanSuoReport.Application.Settings
{
    /// <summary>
    /// 配置项的KEY
    /// </summary>
    public class SettingKeys
    {
        /// <summary>
        /// 用户初始密码
        /// </summary>
        public const string USER_DEFAULT_PASSWORD_KEY = "App.User.DefaultPassword";

        /// <summary>
        /// 用户Token密钥
        /// </summary>
        public const string USER_TOKEN_SECRET_KEY = "App.User.TokenSecret";

        /// <summary>
        /// 用户Token过期时间
        /// </summary>
        public const string USER_TOKEN_EXPIRATION_KEY = "App.User.TokenExpiration";

        /// <summary>
        /// 用户Token刷新时间
        /// </summary>
        public const string USER_TOKEN_REFRESH_TIME_KEY = "App.User.TokenRefreshTime";

        /// <summary>
        /// 开放Token密钥
        /// </summary>
        public const string OPEN_TOKEN_SECRET_KEY = "App.Open.TokenSecret";

        /// <summary>
        /// 开放Token过期时间
        /// </summary>
        public const string OPEN_TOKEN_EXPIRATION_KEY = "App.Open.TokenExpiration";

        /// <summary>
        /// 开放Token刷新时间
        /// </summary>
        public const string OPEN_TOKEN_REFRESH_TIME_KEY = "App.Open.TokenRefreshTime";

        /// <summary>
        /// 允许字典数据不对照
        /// </summary>
        public const string APP_ALLOW_NOT_MAPPING_KEY = "App.Biz.AllowNotMapping";
    }
}
