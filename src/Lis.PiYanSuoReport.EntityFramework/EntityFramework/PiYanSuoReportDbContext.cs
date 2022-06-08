using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics;
using Abp.EntityFramework;
using Lis.PiYanSuoReport.Common.Config;
using Lis.PiYanSuoReport.Core.BaoGao;

namespace Lis.PiYanSuoReport.EntityFramework
{
    public class PiYanSuoReportDbContext : AbpDbContext
    {
        /// <summary>
        /// 数据库连接字符串名称
        /// </summary>
        private const string CONNECTION_STRING_NAME = "OracleDbContext";

        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public DbSet<ViewReport> ViewReports
        {
            get; set;
        }

        public PiYanSuoReportDbContext()
            : base(CONNECTION_STRING_NAME)
        {

        }

        public PiYanSuoReportDbContext(string nameOrConnectionString)
        : base(CONNECTION_STRING_NAME)
        {
        }

        //This constructor is used in tests
        public PiYanSuoReportDbContext(DbConnection existingConnection)
         : base(existingConnection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.Configuration.UseDatabaseNullSemantics = true;
            //Database.SetInitializer<PiYanSuoReportDbContext>(null);
            modelBuilder.HasDefaultSchema(WebConfigHelper.GetValue("App.Database.DefaultSchema"));

            Database.Log = (query) =>
            {
                Debug.Write(query);
            };
            modelBuilder.Entity<ViewReport>().Ignore(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
