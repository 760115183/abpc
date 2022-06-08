using Lis.PiYanSuoReport.EntityFramework;
using System.Data.Entity.Migrations;

namespace Lis.PiYanSuoReport.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PiYanSuoReportDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PiYanSuoReport";
        }

        protected override void Seed(PiYanSuoReportDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
