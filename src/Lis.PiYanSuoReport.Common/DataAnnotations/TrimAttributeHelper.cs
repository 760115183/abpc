using System.Linq;
using System.Text.RegularExpressions;

namespace Lis.PiYanSuoReport.Common.DataAnnotations
{
    /// <summary>
    /// 去空格注解辅助类
    /// </summary>
    public static class TrimAttributeHelper
    {
        /// <summary>
        /// 去除空格
        /// </summary>
        /// <param name="obj"></param>
        public static void Trim(object obj)
        {
            var attributeType = typeof(TrimAttribute);
            var properties = obj.GetType().GetProperties().Where(p => p.IsDefined(attributeType, false)).ToList();
            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    var attribute = prop.GetCustomAttributes(attributeType, false)[0] as TrimAttribute;
                    if (attribute == null)
                    {
                        continue;
                    }

                    if (prop.PropertyType != typeof(string))
                    {
                        continue;
                    }

                    object value = prop.GetValue(obj);
                    if (value == null)
                    {
                        continue;
                    }

                    var trimValue = Regex.Replace(value.ToString(), @"\s", "");
                    prop.SetValue(obj, trimValue);
                }
            }
        }
    }
}
