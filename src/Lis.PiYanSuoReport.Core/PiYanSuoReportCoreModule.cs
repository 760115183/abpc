using System.Reflection;
using Abp.Modules;

namespace Lis.PiYanSuoReport.Core
{
    public class PiYanSuoReportCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
