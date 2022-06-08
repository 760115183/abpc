using Lis.PiYanSuoReport.Common.Extension;
using System;
using System.Configuration;

namespace Lis.PiYanSuoReport.Common.Config
{
    /// <summary>
    /// WebConfig配置辅助类
    /// </summary>
    public static class WebConfigHelper
    {
        public static string GetValue(string key)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            if (value.IsNotNullAndNotEmpty())
            {
                return value;
            }

            throw new SettingsPropertyNotFoundException($"WebConfig中未找到名称为{key}的配置项或配置值不正确");
        }

        public static string GetValue(string key, string defaultVue)
        {
            try
            {
                var value = GetValue(key);
                if (value.IsNotNullAndNotEmpty())
                {
                    return value;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }

            return defaultVue;
        }

        public static int GetValueAsInteger(string key)
        {
            return int.Parse(GetValue(key));
        }

        public static int GetValueAsInteger(string key, int defaultValue)
        {
            var value = GetValue(key);
            if (value.IsNotNullAndNotEmpty())
            {
                return int.Parse(value);
            }

            return defaultValue;
        }

        public static bool GetValueAsBoolean(string key)
        {
            return bool.Parse(GetValue(key));
        }

        public static bool GetValueAsBoolean(string key, bool defaultValue)
        {
            var value = GetValue(key);
            if (value.IsNotNullAndNotEmpty())
            {
                return bool.Parse(value);
            }

            return defaultValue;
        }
    }
}
