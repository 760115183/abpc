using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Lis.PiYanSuoReport.EntityFramework.Repositories
{
    public abstract class PiYanSuoReportRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PiYanSuoReportDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PiYanSuoReportRepositoryBase(IDbContextProvider<PiYanSuoReportDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class PiYanSuoReportRepositoryBase<TEntity> : PiYanSuoReportRepositoryBase<TEntity, string>
        where TEntity : class, IEntity<string>
    {
        protected PiYanSuoReportRepositoryBase(IDbContextProvider<PiYanSuoReportDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
