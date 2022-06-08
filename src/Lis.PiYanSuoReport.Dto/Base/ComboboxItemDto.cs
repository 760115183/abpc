using System;

namespace Lis.PiYanSuoReport.Dto.Base
{
    /// <summary>
    /// 下拉选项DTO
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    [Serializable]
    public class ComboboxItemDto<TValue>
    {
        /// <summary>
        /// 值
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// 显示文本
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ComboboxItemDto()
        {

        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="value"></param>
        /// <param name="displayText"></param>
        public ComboboxItemDto(TValue value, string displayText)
        {
            Value = value;
            DisplayText = displayText;
        }
    }
}
