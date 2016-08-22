using System;
using System.Text;
using Bimface.SDK.Configuation.Authorization;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     验证签名
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class SignatureService
    {
        private readonly Credential credential;

        public SignatureService(Credential credential)
        {
            this.credential = credential;
        }

        /// <summary>
        ///     校验签名方法,针对于回调函数验证是否为bimface发起
        /// </summary>
        /// <param name="signature"> 回调时带的签名 </param>
        /// <param name="viewId"> 转换时返回的预览ID </param>
        /// <param name="status"> 转换状态(success || failed) </param>
        /// <returns> true: 验证成功, false: 校验失败 </returns>
        public virtual bool Validate(string signature, string viewId, string status,String nonce)
        {
            AssertUtils.AssertStringNotNullOrEmpty(signature, "signature");
            AssertUtils.AssertStringNotNullOrEmpty(viewId, "viewId");
            AssertUtils.AssertStringNotNullOrEmpty(status, "status");
            AssertUtils.AssertStringNotNullOrEmpty(status, "nonce");
            // 回调签名 MD5(appKey:appSecret:transferId:status:nonce)
            var sb =
                (new StringBuilder(credential.AppKey)).Append(":")
                    .Append(credential.AppSecret)
                    .Append(":")
                    .Append(viewId)
                    .Append(":")
                    .Append(status)
                    .Append(":")
                    .Append(nonce);
            return signature.Equals(MD5Util.MD5(sb.ToString()), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}