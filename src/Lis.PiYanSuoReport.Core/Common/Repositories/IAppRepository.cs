using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System.Collections.Generic;

namespace Lis.PiYanSuoReport.Core.Repositories
{
    /// <summary>
    /// 通用仓储接口
    /// </summary>
    public interface IAppRepository<TEntity> : IRepository<TEntity, string> where TEntity : class, IEntity<string>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IEnumerable<TEntity> InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 执行查询返回一个或默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T SqlQueryAsFirstOrDefault<T>(string sql, params object[] parameters);

        /// <summary>
        /// 执行查询返回列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<T> SqlQueryAsList<T>(string sql, params object[] parameters);
    }
}
