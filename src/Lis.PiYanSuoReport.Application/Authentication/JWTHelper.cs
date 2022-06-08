using Abp.Dependency;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;

namespace Lis.PiYanSuoReport.Application.Authentication
{
    /// <summary>
    /// Jwt鉴权辅助 类
    /// </summary>
    public class JWTHelper : ISingletonDependency
    {
        #region Consts

        /// <summary>
        /// token的发行者
        /// </summary>
        private const string CLAIM_KEY_ISS = "iss";

        /// <summary>
        ///  token的主题
        /// </summary>
        private const string CLAIM_KEY_SUB = "sub";

        /// <summary>
        /// JWT发布时间，能用于决定JWT年龄
        /// </summary>
        private const string CLAIM_KEY_IAT = "iat";

        /// <summary>
        /// 失效期
        /// </summary>
        private const string CLAIM_KEY_EXP = "exp";

        /// <summary>
        /// 租户ID
        /// </summary>
        private const string CLAIM_KEY_TENANT_ID = "tenantId";

        /// <summary>
        /// 用户ID
        /// </summary>
        private const string CLAIM_KEY_USER_ID = "userId";

        /// <summary>
        /// 用户名
        /// </summary>
        private const string CLAIM_KEY_USER_NAME = "userName";

        /// <summary>
        /// 角色ID
        /// </summary>
        private const string CLAIM_KEY_ROLE_ID = "roleId";

        /// <summary>
        /// 是否静态用户
        /// </summary>
        private const string CLAIM_KEY_IS_STATIC = "isStatic";

        /// <summary>
        /// 是否管理员用户
        /// </summary>
        private const string CLAIM_KEY_IS_ADMIN = "isAdmin";

        /// <summary>
        /// 机构系统编码
        /// </summary>
        private const string CLAIM_KEY_ORGANIZATION_UNIT_CODE = "organizationUnitCode";

        /// <summary>
        /// 医疗机构代码
        /// </summary>
        private const string CLAIM_KEY_YI_LIAO_JGDM = "yiLiaoJGDM";

        /// <summary>
        /// 医疗机构名称
        /// </summary>
        private const string CLAIM_KEY_YI_LIAO_JGMC = "yiLiaoJGMC";

        #endregion

        private readonly IDateTimeProvider provider;
        private readonly IJwtAlgorithm algorithm;
        private readonly IJsonSerializer serializer;
        private readonly IBase64UrlEncoder urlEncoder;
        private readonly IJwtEncoder encoder;
        private readonly IJwtValidator validator;
        private readonly IJwtDecoder decoder;

        /// <summary>
        /// Unix开始时间
        /// </summary>
        private readonly DateTime unixEpoch;

        public JWTHelper()
        {
            provider = new UtcDateTimeProvider();
            algorithm = new HMACSHA256Algorithm();
            serializer = new JsonNetSerializer();
            urlEncoder = new JwtBase64UrlEncoder();
            encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            validator = new JwtValidator(serializer, provider);
            decoder = new JwtDecoder(serializer, validator, urlEncoder);

            unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }

        /// <summary>
        /// 创建token
        /// </summary>
        /// <returns></returns>
        public string CreateToken(JWTInfo info, string secret, int expiration)
        {
            return BuildToken(info, secret, expiration);
        }

        /// <summary>
        /// 刷新token
        /// </summary>
        /// <param name="claims"></param>
        /// <returns>空值表示不需要更新TOKEN</returns>
        public string RefreshToken(JWTInfo info, string secret, int expiration, int refreshTime)
        {
            if (this.NeedRefresh(info, refreshTime))
            {
                return BuildToken(info, secret, expiration);
            }

            return string.Empty;
        }

        /// <summary>
        /// 解析token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public JWTInfo ParseToken(string token, string secret)
        {
            var claims = this.DecodeToken(token, secret);

            return new JWTInfo
            {
                UserId = claims[CLAIM_KEY_USER_ID].ToString(),
                UserName = claims[CLAIM_KEY_USER_NAME].ToString(),
                Expire = long.Parse(claims[CLAIM_KEY_EXP].ToString())
            };
        }

        /// <summary>
        /// 判断token是否需要刷新
        /// </summary>
        /// <param name="info"></param>
        /// <param name="refreshTime">刷新时间</param>
        /// <returns></returns>
        private bool NeedRefresh(JWTInfo info, int refreshTime)
        {
            var now = provider.GetNow();
            var seconds = Math.Round((now - unixEpoch).TotalSeconds);

            double diff = info.Expire - seconds;

            //已过期,不允许刷新
            if (diff <= 0)
            {
                return false;
            }

            //未过期, 过期时间-当前时间 所得的差值 <= 更新阀值 时,则允许更新
            if (diff <= (refreshTime * 60))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 创建token
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private string BuildToken(JWTInfo info, string secret, int expiration)
        {
            var now = provider.GetNow();
     
            var payload = new Dictionary<string, object>
            {
                { CLAIM_KEY_IAT, now },
                { CLAIM_KEY_EXP, GetExpirationTime(now, expiration) },

                { CLAIM_KEY_USER_ID, info.UserId },
                { CLAIM_KEY_USER_NAME, info.UserName },
            };

            return encoder.Encode(payload, secret);
        }

        /// <summary>
        /// 解析token
        /// </summary>
        /// <param name="token">jwtToken</param>
        /// <returns></returns>
        private IDictionary<string, object> DecodeToken(string token, string secret)
        {
            return decoder.DecodeToObject(token, secret, verify: true);
        }

        /// <summary>
        /// 获取过期时间
        /// </summary>
        /// <param name="iat">token颁发时间</param>
        /// <param name="expiration">token过期时间</param>
        /// <returns></returns>
        private double GetExpirationTime(DateTime iat, int expiration)
        {
            return Math.Round((iat - unixEpoch).TotalSeconds) + expiration * 60;
        }
    }
}
