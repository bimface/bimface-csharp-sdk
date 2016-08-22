using System;
using Bimface.SDK.Configuation;
using Bimface.SDK.Http;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     ҵ����ĳ����࣬�����ҪAccessToken��ʵ��
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public abstract class AbstractAccessTokenService : AbstractService
    {
        private readonly AccessTokenService accessTokenService;

        public AbstractAccessTokenService()
        {
        }

        public AbstractAccessTokenService(ServiceClient serviceClient, Endpoint endpoint,
            AccessTokenService accessTokenService) : base(serviceClient, endpoint)
        {
            this.accessTokenService = accessTokenService;
        }

        public virtual string AccessToken
        {
            get
            {
                var accessTokenBean = accessTokenService.Get();
                if (accessTokenBean == null)
                {
                    throw new NullReferenceException("AccessTokenBean is null, can not Get access token.");
                }
                return accessTokenBean.Token;
            }
        }
    }
}