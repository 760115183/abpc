using Abp.Application.Services;

namespace Lis.PiYanSuoReport
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class PiYanSuoReportAppServiceBase : ApplicationService
    {
        protected PiYanSuoReportAppServiceBase()
        {
            LocalizationSourceName = PiYanSuoReportConsts.LocalizationSourceName;
        }
    }
}