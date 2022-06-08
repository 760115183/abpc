using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using System;

namespace Lis.PiYanSuoReport.EntityFramework.EntityFramework.Repositories
{
    public abstract class AppRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PiYanSuoReportDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AppRepositoryBase(IDbContextProvider<PiYanSuoReportDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class AppRepositoryBase<TEntity> : AppRepositoryBase<TEntity, string>
        where TEntity : class, IEntity<string>
    {
        protected AppRepositoryBase(IDbContextProvider<PiYanSuoReportDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
