using System;

namespace Lis.PiYanSuoReport.Common.DataAnnotations
{
    /// <summary>
    /// 去空格注解
    /// 说明: 使用该注解后, 属性值中的所有空格将会被过滤
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class TrimAttribute : Attribute
    {
    }
}
