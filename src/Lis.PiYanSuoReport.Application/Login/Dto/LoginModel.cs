using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.PiYanSuoReport.Login.Dto
{
    public class LoginModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string UserName { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        [Required(ErrorMessage = "请输入证件号")]
        public string ZhengJianHao { get; set; }
    }
}
