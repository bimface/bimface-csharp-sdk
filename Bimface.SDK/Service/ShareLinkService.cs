using System;
using Bimface.SDK.Bean.Response;
using Bimface.SDK.Configuation;
using Bimface.SDK.Http;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     分享链接
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class ShareLinkService : AbstractAccessTokenService
    {
        private readonly bool InstanceFieldsInitialized;
        private string CREATE_SHARE_URL;
        private string CREATE_SHARE_URL_FOREVER;
        private string DELETE_SHARE_URL;
        private string GET_SHARE_URL;
        private string UPDATE_SHARE_URL;

        public ShareLinkService(ServiceClient serviceClient, Endpoint endpoint, AccessTokenService accessTokenService)
            : base(serviceClient, endpoint, accessTokenService)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
        }

        private void InitializeInstanceFields()
        {
            CREATE_SHARE_URL = ApiHost + "/share?viewId={0}&activeHours={1}";
            CREATE_SHARE_URL_FOREVER = ApiHost + "/share?viewId={0}";
            UPDATE_SHARE_URL = ApiHost + "/share?viewId={0}&activeHours={1}";
            GET_SHARE_URL = ApiHost + "/share?viewId={0}";
            DELETE_SHARE_URL = ApiHost + "/share?viewId={0}";
        }

        public virtual ShareLinkBean Create(string viewId, int? activeHours)
        {
            // 参数校验
            AssertUtils.AssertStringNotNullOrEmpty(viewId, "viewId");
            if (activeHours != null && activeHours <= 0)
            {
                throw new ArgumentException("activeHours must not less than zero.");
            }

            var headers = new HttpHeaders();
            headers.AddOAuth2Header(AccessToken);
            var response = ServiceClient.Post(string.Format(CREATE_SHARE_URL, viewId, activeHours), "", headers);
            return HttpUtils.Response<ShareLinkBean>(response);
        }

        public virtual ShareLinkBean Create(string viewId)
        {
            // 参数校验
            AssertUtils.AssertStringNotNullOrEmpty(viewId, "viewId");

            var headers = new HttpHeaders();
            headers.AddOAuth2Header(AccessToken);
            var response = ServiceClient.Post(string.Format(CREATE_SHARE_URL_FOREVER, viewId), "", headers);
            return HttpUtils.Response<ShareLinkBean>(response);
        }

        public virtual string Delete(string viewId)
        {
            // 参数校验
            AssertUtils.AssertStringNotNullOrEmpty(viewId, "viewId");

            var headers = new HttpHeaders();
            headers.AddOAuth2Header(AccessToken);
            var response = ServiceClient.Delete(string.Format(DELETE_SHARE_URL, viewId), headers);
            return HttpUtils.Response<string>(response);
        }
    }
}