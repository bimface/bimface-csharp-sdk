using System.Collections.Generic;
using Bimface.SDK.Configuation;
using Bimface.SDK.Http;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     支持的文件格式
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class SupportFileService : AbstractAccessTokenService
    {
        private readonly bool InstanceFieldsInitialized;
        private string SUPPORT_FILE_URL;
        private IList<string> supportFile;

        public SupportFileService(ServiceClient serviceClient, Endpoint endpoint, AccessTokenService accessTokenService)
            : base(serviceClient, endpoint, accessTokenService)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
        }

        public virtual IList<string> SupportFile
        {
            get
            {
                // 在缓存中获取
                if (supportFile != null && supportFile.Count > 0)
                {
                    return supportFile;
                }

                var headers = new HttpHeaders();
                headers.AddOAuth2Header(AccessToken);
                var response = ServiceClient.Get(SUPPORT_FILE_URL, headers);
                supportFile = HttpUtils.Response<IList<string>>(response);
                return supportFile;
            }
        }

        private void InitializeInstanceFields()
        {
            SUPPORT_FILE_URL = string.Format("{0}/support", ApiHost);
        }
    }
}