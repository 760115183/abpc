using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Lis.PiYanSuoReport.Core;

namespace Lis.PiYanSuoReport
{
    [DependsOn(typeof(PiYanSuoReportCoreModule), typeof(AbpAutoMapperModule))]
    public class PiYanSuoReportApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
