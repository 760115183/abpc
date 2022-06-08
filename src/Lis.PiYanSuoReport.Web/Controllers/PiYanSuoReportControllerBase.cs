using Abp.Web.Mvc.Controllers;

namespace Lis.PiYanSuoReport.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class PiYanSuoReportControllerBase : AbpController
    {
        protected PiYanSuoReportControllerBase()
        {
            LocalizationSourceName = PiYanSuoReportConsts.LocalizationSourceName;
        }
    }
}