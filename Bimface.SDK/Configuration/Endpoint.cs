using System;
using Bimface.SDK.Constants;

namespace Bimface.SDK.Configuation
{
    /// <summary>
    ///     API调用地址入口
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public sealed class Endpoint
    {
        private string apiHost = BimfaceConstants.API_HOST; // API地址
        private string fileHost = BimfaceConstants.FILE_HOST; // 文件API地址

        public Endpoint()
        {
        }

        public Endpoint(string apiHost, string fileHost)
        {
            Check(apiHost, fileHost);
            this.apiHost = apiHost;
            this.fileHost = fileHost;
        }

        public string ApiHost
        {
            get { return apiHost; }
            set { apiHost = value; }
        }

        public string FileHost
        {
            get { return fileHost; }
            set { fileHost = value; }
        }

        private void Check(string apiHost, string fileHost)
        {
            if (string.IsNullOrEmpty(apiHost))
            {
                throw new ArgumentException("apiHost should not be null or empty.");
            }
            if (string.IsNullOrEmpty(fileHost))
            {
                throw new ArgumentException("fileHost should not be null or empty.");
            }
        }
    }
}