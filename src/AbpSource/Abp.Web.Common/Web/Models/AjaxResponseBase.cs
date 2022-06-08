namespace Abp.Web.Models
{
    public interface IAjaxResponse
    {
        bool Success { get; set; }

        ErrorInfo Error { get; set; }
    }

    public abstract class AjaxResponseBase : IAjaxResponse
    {
        /// <summary>
        /// This property can be used to redirect user to a specified URL.
        /// </summary>
        //public string TargetUrl { get; set; }

        /// <summary>
        /// 处理是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误信息
        /// 当success为false, 返回错误信息
        /// </summary>
        public ErrorInfo Error { get; set; }

        /// <summary>
        /// This property can be used to indicate that the current user has no privilege to perform this request.
        /// </summary>
        //public bool UnAuthorizedRequest { get; set; }

        /// <summary>
        /// A special signature for AJAX responses. It's used in the client to detect if this is a response wrapped by ABP.
        /// </summary>
        //public bool __abp { get; } = true;
    }
}
