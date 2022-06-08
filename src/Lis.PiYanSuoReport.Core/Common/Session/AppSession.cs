using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Runtime.Session;
using LXG.Core.Common.Security;
using System.Linq;
using System.Security.Claims;

namespace Lis.PiYanSuoReport.Core.Common.Session
{
    public class AppSession : ClaimsAbpSession, IAppSession, ISingletonDependency
    {
        public AppSession(IMultiTenancyConfig multiTenancy) :base(multiTenancy)
        {
        }

        public bool IsStatic
        {
            get
            {
                var claim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.IsStatic);
                if (string.IsNullOrEmpty(claim?.Value))
                {
                    return false;
                }

                bool isStatic;
                if (!bool.TryParse(claim.Value, out isStatic))
                {
                    return false;
                }

                return isStatic;
            }
        }

        public bool IsAdmin
        {
            get
            {
                var claim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.IsAdmin);
                if (string.IsNullOrEmpty(claim?.Value))
                {
                    return false;
                }

                bool isAdmin;
                if (!bool.TryParse(claim.Value, out isAdmin))
                {
                    return false;
                }

                return isAdmin;
            }
        }

        public string UserName
        {
            get
            {
                var claim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                if (string.IsNullOrEmpty(claim?.Value))
                {
                    return null;
                }

                return claim.Value;
            }
        }

        public string OrganizationUnitCode
        {
            get
            {
                var claim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.OrganizationUnitCode);
                if (string.IsNullOrEmpty(claim?.Value))
                {
                    return null;
                }

                return claim.Value;
            }
        }

        public string YiLiaoJGDM
        {
            get
            {
                var claim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.YiLiaoJGDM);
                if (string.IsNullOrEmpty(claim?.Value))
                {
                    return null;
                }

                return claim.Value;
            }
        }

        public string YiLiaoJGMC
        {
            get
            {
                var claim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.YiLiaoJGMC);
                if (string.IsNullOrEmpty(claim?.Value))
                {
                    return null;
                }

                return claim.Value;
            }
        }
    }
}
