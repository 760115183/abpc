using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.PiYanSuoReport.Application.BaoGao.Dto
{
    public class QueryYangBenXXOutput
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string DateStr { get; set; }

        /// <summary>
        /// 报告列表
        /// </summary>
        public List<QueryYangBenXXDTO> Items { get; set; }
    }
}
