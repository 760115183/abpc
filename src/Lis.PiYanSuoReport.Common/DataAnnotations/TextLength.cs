using System.ComponentModel.DataAnnotations;

namespace Lis.PiYanSuoReport.Common.DataAnnotations
{
    /// <summary>
    /// 文本长度校验
    /// </summary>
    public class TextLengthAttribute : ValidationAttribute
    {
        /// <summary>
        /// 向构造函数中传递一个默认的错误提示消息，包含一个参数占位符{0}
        /// </summary>
        /// <param name="max"></param>
        public TextLengthAttribute(int max) : base("{0}的字符超过限定长度(汉字占2个长度, 字母或数字占1个长度)")
        {
            _max = max;
        }

        /// <summary>
        /// 第一个参数是验证对象的值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (StrLength(valueAsString) > _max)
                {
                    //FormatErrorMessage方法会自动使用显示的属性名称来格式化这个字符串
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        public static int StrLength(string inputString)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }

        private readonly int _max;
    }
}
