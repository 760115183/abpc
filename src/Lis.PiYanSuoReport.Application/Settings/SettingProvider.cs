using Abp.Dependency;
using Abp.Runtime.Caching;
using Castle.Core.Logging;
using Lis.PiYanSuoReport.Common.Config;

namespace Lis.PiYanSuoReport.Application.Settings
{
    public class SettingProvider : ISettingProvider, ISingletonDependency
    {
        private const string CACHE_NAME = "SYS_SETTINGS";

        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        public SettingProvider(ICacheManager cacheManager, ILogger logger)
        {
            _cacheManager = cacheManager;
            _logger = logger;
        }

        public string GetUserTokenSecret()
        {
            string value = _cacheManager.GetCache(CACHE_NAME).Get(SettingKeys.USER_TOKEN_SECRET_KEY, () =>
            {
                _logger.InfoFormat("读取设置项{0}时缓存未命中,从数据库读取", SettingKeys.USER_TOKEN_SECRET_KEY);

                return WebConfigHelper.GetValue(SettingKeys.USER_TOKEN_SECRET_KEY);
            });

            return value;
        }

        public int GetUserTokenExpiration()
        {
            int value = _cacheManager.GetCache(CACHE_NAME).Get(SettingKeys.USER_TOKEN_EXPIRATION_KEY, () =>
            {
                _logger.InfoFormat("读取设置项{0}时缓存未命中,从数据库读取", SettingKeys.USER_TOKEN_EXPIRATION_KEY);

                return WebConfigHelper.GetValueAsInteger(SettingKeys.USER_TOKEN_EXPIRATION_KEY);
            });

            return value;
        }

        public int GetUserTokenRefreshTime()
        {
            int value = _cacheManager.GetCache(CACHE_NAME).Get(SettingKeys.USER_TOKEN_REFRESH_TIME_KEY, () =>
            {
                _logger.InfoFormat("读取设置项{0}时缓存未命中,从数据库读取", SettingKeys.USER_TOKEN_REFRESH_TIME_KEY);

                return WebConfigHelper.GetValueAsInteger(SettingKeys.USER_TOKEN_REFRESH_TIME_KEY);
            });

            return value;
        }

        public string GetOpenTokenSecret()
        {
            string value = _cacheManager.GetCache(CACHE_NAME).Get(SettingKeys.OPEN_TOKEN_SECRET_KEY, () =>
            {
                _logger.InfoFormat("读取设置项{0}时缓存未命中,从数据库读取", SettingKeys.OPEN_TOKEN_SECRET_KEY);

                return WebConfigHelper.GetValue(SettingKeys.OPEN_TOKEN_SECRET_KEY);
            });

            return value;
        }

        public int GetOpenTokenExpiration()
        {
            int value = _cacheManager.GetCache(CACHE_NAME).Get(SettingKeys.OPEN_TOKEN_EXPIRATION_KEY, () =>
            {
                _logger.InfoFormat("读取设置项{0}时缓存未命中,从数据库读取", SettingKeys.OPEN_TOKEN_EXPIRATION_KEY);

                return WebConfigHelper.GetValueAsInteger(SettingKeys.OPEN_TOKEN_EXPIRATION_KEY);
            });

            return value;
        }

        public int GetOpenTokenRefreshTime()
        {
            int value = _cacheManager.GetCache(CACHE_NAME).Get(SettingKeys.OPEN_TOKEN_REFRESH_TIME_KEY, () =>
            {
                _logger.InfoFormat("读取设置项{0}时缓存未命中,从数据库读取", SettingKeys.OPEN_TOKEN_REFRESH_TIME_KEY);

                return WebConfigHelper.GetValueAsInteger(SettingKeys.OPEN_TOKEN_REFRESH_TIME_KEY);
            });

            return value;
        }

        public bool GetAllowNotMapping()
        {
            bool value = _cacheManager.GetCache(CACHE_NAME).Get(SettingKeys.APP_ALLOW_NOT_MAPPING_KEY, () =>
            {
                _logger.InfoFormat("读取设置项{0}时缓存未命中,从数据库读取", SettingKeys.APP_ALLOW_NOT_MAPPING_KEY);

                return WebConfigHelper.GetValueAsBoolean(SettingKeys.APP_ALLOW_NOT_MAPPING_KEY);
            });

            return value;
        }
    }
}
