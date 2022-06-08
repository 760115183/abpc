using Abp.UI;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Lis.PiYanSuoReport.Common.Exceptions
{
    /// <summary>
    /// 用户友好异常创建类
    /// </summary>
    public static class UserFriendlyExceptionCreator
    {
        /// <summary>
        /// 创建异常
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="message">错误消息</param>
        /// <returns></returns>
        public static UserFriendlyException Create(ErrorCodes code, string message)
        {
            string description = message;

            if (code != ErrorCodes.Failure)
            {
                description = GetDescription(code);
            }

            return new UserFriendlyException((int)code, message, description);
        }

        /// <summary>
        /// 创建异常
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="message">错误消息</param>
        /// <param name="innerException">内部异常</param>
        /// <returns></returns>
        public static UserFriendlyException Create(ErrorCodes code, string message, Exception innerException)
        {
            //在未指定错误明细的情况下,从枚举描述中获取
            string description = GetDescription(code);

            return new UserFriendlyException((int)code, message, description + innerException.Message + innerException.InnerException?.Message + innerException.StackTrace);
        }

        /// <summary>
        /// 创建异常
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="message">错误消息</param>
        /// <param name="details">错误详细信息</param>
        /// <returns></returns>
        public static UserFriendlyException Create(ErrorCodes code, string message, string details)
        {
            return new UserFriendlyException((int)code, message, details);
        }

        /// <summary>
        /// 创建异常
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="message">错误消息</param>
        /// <param name="details">错误详细信息</param>
        /// <param name="innerException">内部异常</param>
        /// <returns></returns>
        public static UserFriendlyException Create(ErrorCodes code, string message, string details, Exception innerException)
        {
            return new UserFriendlyException((int)code, message, details + innerException.Message + innerException.InnerException?.Message + innerException.StackTrace);
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetDescription(Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }

            return string.Empty;
        }
    }
}
