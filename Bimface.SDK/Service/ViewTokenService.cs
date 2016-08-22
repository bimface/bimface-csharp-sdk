using Bimface.SDK.Configuation;
using Bimface.SDK.Http;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     获取viewToken
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class ViewTokenService : AbstractAccessTokenService
    {
        private readonly bool InstanceFieldsInitialized;
        private string VIEW_TOKEN_URL;

        public ViewTokenService(ServiceClient serviceClient, Endpoint endpoint, AccessTokenService accessTokenService)
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
            VIEW_TOKEN_URL = ApiHost + "/view/token?viewId={0}";
        }

        public virtual string GrantViewToken(string viewId)
        {
            AssertUtils.AssertStringNotNullOrEmpty(viewId, "viewId");
            var headers = new HttpHeaders();
            headers.AddOAuth2Header(AccessToken);
            var response = ServiceClient.Get(string.Format(VIEW_TOKEN_URL, viewId), headers);
            return HttpUtils.Response<string>(response);
        }
    }
}