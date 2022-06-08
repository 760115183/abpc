using Abp.Runtime.Session;

namespace Lis.PiYanSuoReport.Core.Common.Session
{
    public interface IAppSession : IAbpSession
    {
        /// <summary>
        /// 静态用户(系统部署时默认帐号)
        /// </summary>
        bool IsStatic
        {
            get;
        }

        /// <summary>
        /// 是否管理员
        /// </summary>
        bool IsAdmin
        {
            get;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        string UserName
        {
            get;
        }

        /// <summary>
        /// 组织机构系统编码
        /// </summary>
        string OrganizationUnitCode
        {
            get;
        }

        /// <summary>
        /// 医疗机构代码
        /// </summary>
        string YiLiaoJGDM
        {
            get;
        }

        /// <summary>
        /// 医疗机构名称
        /// </summary>
        string YiLiaoJGMC
        {
            get;
        }
    }
}
