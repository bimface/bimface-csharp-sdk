using System.Collections.Generic;
using Bimface.SDK.Configuation;
using Bimface.SDK.Http;
using Bimface.SDK.Bean.Response;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     支持的文件格式
    ///     @author bimface, 2016-09-01.
    /// </summary>
    public class SupportFileService : AbstractAccessTokenService
    {
        private readonly bool InstanceFieldsInitialized;
        private string SUPPORT_FILE_URL;
        private SupportFileBean supportFileBean;

        public SupportFileService(ServiceClient serviceClient, Endpoint endpoint, AccessTokenService accessTokenService)
            : base(serviceClient, endpoint, accessTokenService)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
        }

        public virtual SupportFileBean GetSupport
        {
            get
            {
                // 在缓存中获取
                if (supportFileBean != null)
                {
                    return supportFileBean;
                }

                var headers = new HttpHeaders();
                headers.AddOAuth2Header(AccessToken);
                var response = ServiceClient.Get(SUPPORT_FILE_URL, headers);
                supportFileBean = HttpUtils.Response<SupportFileBean>(response);
                return supportFileBean;
            }
        }

        private void InitializeInstanceFields()
        {
            SUPPORT_FILE_URL = string.Format("{0}/support", FileHost);
        }
    }
}