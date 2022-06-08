using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Lis.PiYanSuoReport.Core;
using Lis.PiYanSuoReport.EntityFramework;

namespace Lis.PiYanSuoReport
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(PiYanSuoReportCoreModule))]
    public class PiYanSuoReportDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PiYanSuoReportDbContext>());

            Configuration.UnitOfWork.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;//ORA-08177
            Configuration.DefaultNameOrConnectionString = "Default";

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //Database.SetInitializer<PiYanSuoReportDbContext>(null);
        }
    }
}
