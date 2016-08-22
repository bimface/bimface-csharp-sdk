using Bimface.SDK.Configuation;
using Bimface.SDK.Http;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     业务处理的抽象类
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public abstract class AbstractService
    {
        private readonly Endpoint endpoint;
        private readonly ServiceClient serviceClient;

        public AbstractService()
        {
        }

        public AbstractService(ServiceClient serviceClient, Endpoint endpoint)
        {
            this.serviceClient = serviceClient;
            this.endpoint = endpoint;
        }

        public virtual ServiceClient ServiceClient
        {
            get { return serviceClient; }
        }

        public virtual string ApiHost
        {
            get { return endpoint.ApiHost; }
        }

        public virtual string FileHost
        {
            get { return endpoint.FileHost; }
        }
    }
}