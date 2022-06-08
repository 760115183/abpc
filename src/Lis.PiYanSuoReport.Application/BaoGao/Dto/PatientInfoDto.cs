using Abp.AutoMapper;
using Lis.PiYanSuoReport.Core.BaoGao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.PiYanSuoReport.Application.BaoGao.Dto
{
    [AutoMapFrom(typeof(ViewReport))]
    public class PatientInfoDto
    {
        /// <summary>
        /// 
        /// </summary>
        public bool NotFound { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string SFZH { get; set; }

        /// <summary>
        /// 门诊号 （门诊就诊卡号，如住院病人可为空）
        /// </summary>
        public string OutPatientID { get; set; }
    }
}
