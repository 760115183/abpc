using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.PiYanSuoReport.Application.BaoGao.Dto
{
    public class QueryPatientInfoInput
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string UserName
        {
            get; set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "请输入身份证号")]
        public string ZhengJianHao
        {
            get; set;
        }
    }
}
