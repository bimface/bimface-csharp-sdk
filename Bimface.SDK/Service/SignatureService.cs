using System;
using System.Text;
using Bimface.SDK.Configuation.Authorization;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     ��֤ǩ��
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
        ///     У��ǩ������,����ڻص�������֤�Ƿ�Ϊbimface����
        /// </summary>
        /// <param name="signature"> �ص�ʱ����ǩ�� </param>
        /// <param name="viewId"> ת��ʱ���ص�Ԥ��ID </param>
        /// <param name="status"> ת��״̬(success || failed) </param>
        /// <returns> true: ��֤�ɹ�, false: У��ʧ�� </returns>
        public virtual bool Validate(string signature, string viewId, string status,String nonce)
        {
            AssertUtils.AssertStringNotNullOrEmpty(signature, "signature");
            AssertUtils.AssertStringNotNullOrEmpty(viewId, "viewId");
            AssertUtils.AssertStringNotNullOrEmpty(status, "status");
            AssertUtils.AssertStringNotNullOrEmpty(status, "nonce");
            // �ص�ǩ�� MD5(appKey:appSecret:transferId:status:nonce)
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