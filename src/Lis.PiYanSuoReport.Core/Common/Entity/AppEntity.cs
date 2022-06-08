using Abp.Domain.Entities;

namespace Lis.PiYanSuoReport.Core.Common.Entity
{
    /// <summary>
    /// 仅包含ID字段的抽象实体
    /// </summary>
    public abstract class AppEntity<TPrimaryKey> : Entity<TPrimaryKey>
    {
    }
}
