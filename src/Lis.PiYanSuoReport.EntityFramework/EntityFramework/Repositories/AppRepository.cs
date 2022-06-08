using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFramework;
using Lis.PiYanSuoReport.Common.DataAnnotations;
using Lis.PiYanSuoReport.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lis.PiYanSuoReport.EntityFramework.EntityFramework.Repositories
{
    /// <summary>
    /// 通用仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class AppRepository<TEntity> : AppRepositoryBase<TEntity>, IRepository<TEntity,string> where TEntity : class, IEntity<string>
    {
        protected readonly IUnitOfWorkManager _UnitOfWorkManager;

        public AppRepository(IDbContextProvider<PiYanSuoReportDbContext> dbContextProvider, IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider)
        {
            _UnitOfWorkManager = unitOfWorkManager;             
        }

        public IEnumerable<TEntity> InsertRange(IEnumerable<TEntity> entities)
        {
            return Table.AddRange(entities);
        }

        public Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            return Task.FromResult(Table.AddRange(entities));
        }

        public T SqlQueryAsFirstOrDefault<T>(string sql, params object[] parameters)
        {           
            return Context.Database.SqlQuery<T>(sql, parameters).FirstOrDefault();
        }

        public IList<T> SqlQueryAsList<T>(string sql, params object[] parameters)
        {
            return Context.Database.SqlQuery<T>(sql, parameters).ToList();
        }

        public override TEntity Insert(TEntity entity)
        {
            TrimAttributeHelper.Trim(entity);

            return base.Insert(entity);
        }

        public override Task<TEntity> InsertAsync(TEntity entity)
        {
            TrimAttributeHelper.Trim(entity);

            return base.InsertAsync(entity);
        }

        public override TEntity Update(TEntity entity)
        {
            TrimAttributeHelper.Trim(entity);

            return base.Update(entity);
        }

        public override Task<TEntity> UpdateAsync(TEntity entity)
        {
            TrimAttributeHelper.Trim(entity);

            return base.UpdateAsync(entity);
        }
    }
}
