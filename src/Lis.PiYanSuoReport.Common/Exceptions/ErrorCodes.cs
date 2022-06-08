using System.ComponentModel;

namespace Lis.PiYanSuoReport.Common.Exceptions
{
    /// <summary>
    /// 错误码
    /// </summary>
    public enum ErrorCodes
    {
        [Description("处理失败")]
        Failure = -1,

        [Description("处理成功")]
        Success = 0,

        #region 系统错误(10001~19999)

        [Description("非接口用户")]
        NotApiUser = 10001,

        [Description("非平台用户")]
        NotPlatformUser = 10005,

        [Description("用户名或密码不正确")]
        UserNameOrPasswordIncorrect = 10010,        

        [Description("用户未激活或未登录")]
        UserIsNotActive = 10015,

        [Description("用户认证失败")]
        UserAuthenticationFailure = 10020,

        [Description("原密码不正确")]
        OriginalPasswordIncorrect = 10025,

        [Description("读取配置失败")]
        SettingNotFound = 10101,

        #endregion

        #region 系统模块错误(20001~29999)



        #endregion

        #region 业务模块错误(30001~39999)

        [Description("请求参数无效")]
        InvalidParameter = 30001,

        [Description("请求参数不能为空")]
        NotNullParameter = 30002,

        [Description("标本流转信息不存在")]
        SpecimenLZXXNotFound = 31001,

        [Description("条码号不存在")]
        TiaoMaoHaoNotFound = 32001,

        [Description("已存在相同的编码")]
        DuplicationBusinessCode = 32002,

        [Description("记录不存在")]
        RecordNotFound = 32003,

        [Description("标本已上传")]
        SpecimenExists = 32010,

        [Description("检验报告未找到")]
        TestResultNotFound = 32050,

        #endregion

        #region Token错误

        [Description("Token无效")]
        IllegalToken = 50008,

        [Description("Token不存在")]
        TokenNotFound = 50010,

        [Description("Token已过期")]
        TokenExpired = 50014

        #endregion
    }
}
