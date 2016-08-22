using Bimface.SDK.Bean.Response;
using Bimface.SDK.Configuation;
using Bimface.SDK.Configuation.Authorization;
using Bimface.SDK.Http;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     获取AccessToken
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public sealed class AccessTokenService : AbstractService
    {
        private readonly AccessTokenStorage accessTokenStorage;
        private readonly Credential credential;
        private readonly bool InstanceFieldsInitialized;
        private string ACCESS_TOKEN_URL;

        public AccessTokenService(ServiceClient serviceClient, Endpoint endpoint, Credential credential,
            AccessTokenStorage accessTokenStorage) : base(serviceClient, endpoint)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            this.credential = credential;
            this.accessTokenStorage = accessTokenStorage;
        }

        private void InitializeInstanceFields()
        {
            ACCESS_TOKEN_URL = ApiHost + "/oauth2/token";
        }

        public AccessTokenBean Get()
        {
            var accessTokenBean = accessTokenStorage.Get();
            if (accessTokenBean == null)
            {
                accessTokenBean = Grant();
                accessTokenStorage.Put(accessTokenBean);
            }
            return accessTokenBean;
        }

        private AccessTokenBean Grant()
        {
            var headers = new HttpHeaders();
            headers.AddBasicAuthHeader(credential.AppKey, credential.AppSecret);
            var response = ServiceClient.Post(ACCESS_TOKEN_URL, ServiceClient.EmptyRequestBody, headers);
            return HttpUtils.Response<AccessTokenBean>(response);
        }
    }
}