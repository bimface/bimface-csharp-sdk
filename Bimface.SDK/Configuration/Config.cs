using Bimface.SDK.Constants;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Configuation
{
    /// <summary>
    ///     配置
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class Config
    {
        private static readonly string DEFAULT_USER_AGENT = VersionInfoUtils.DefaultUserAgent;
        private int connectTimeout = BimfaceConstants.DEFAULT_CONNECT_TIMEOUT;
        private long keepAliveDurationNs = BimfaceConstants.DEFAULT_KEEP_ALIVE_DURATION_NS;
        private int maxIdleConnections = BimfaceConstants.DEFAULT_MAX_IDLE_CONNECTIONS;
        private int maxRequests = BimfaceConstants.DEFAULT_MAX_REQUESTS;
        private int maxRequestsPerHost = BimfaceConstants.DEFAULT_MAX_REQUESTS_PER_HOST;
        private int readWriteWriteTimeout = BimfaceConstants.DEFAULT_READ_WRITE_TIMEOUT;
        private int responseTimeout = BimfaceConstants.DEFAULT_RESPONSE_TIMEOUT;
        private string userAgent = DEFAULT_USER_AGENT;
        private int writeTimeout = BimfaceConstants.DEFAULT_WRITE_TIMEOUT;

        /// <summary>
        ///     获取或设置：用户代理
        /// </summary>
        /// <returns> 用户代理 </returns>
        public virtual string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }

        /// <summary>
        ///     获取或设置：最大空闲连接数
        /// </summary>
        /// <returns> 最大空闲连接数 </returns>
        public virtual int MaxIdleConnections
        {
            get { return maxIdleConnections; }
            set { maxIdleConnections = value; }
        }

        /// <summary>
        ///     获取或设置：保持活动周期时长
        /// </summary>
        /// <returns> 保持活动周期时长（单位：纳秒） </returns>
        public virtual long KeepAliveDurationNs
        {
            get { return keepAliveDurationNs; }
            set { keepAliveDurationNs = value; }
        }

        /// <summary>
        ///     获取或设置：允许打开的最大请求数
        /// </summary>
        /// <returns> 最大请求数 </returns>
        public virtual int MaxRequests
        {
            get { return maxRequests; }
            set { maxRequests = value; }
        }

        /// <summary>
        ///     获取或设置：每台主机最大的请求数
        /// </summary>
        /// <returns> 每台主机最大的请求数 </returns>
        public virtual int MaxRequestsPerHost
        {
            get { return maxRequestsPerHost; }
            set { maxRequestsPerHost = value; }
        }

        /// <summary>
        ///     获取或设置：建立连接的超时时间（单位：秒）
        /// </summary>
        /// <returns> 建立连接的超时时间（单位：秒） </returns>
        public virtual int ConnectTimeout
        {
            get { return connectTimeout; }
            set { connectTimeout = value; }
        }

        /// <summary>
        ///     获取或设置：获取响应的超时时间
        /// </summary>
        /// <returns> 获取响应的超时时间 </returns>
        public virtual int ReadWriteTimeout
        {
            get { return readWriteWriteTimeout; }
            set { readWriteWriteTimeout = value; }
        }

        /// <summary>
        ///     获取或设置：写入请求的超时时间
        /// </summary>
        /// <returns> 写入请求的超时时间 </returns>
        public virtual int WriteTimeout
        {
            get { return writeTimeout; }
            set { writeTimeout = value; }
        }

        /// <summary>
        ///     获取或设置：响应请求的超时时间
        /// </summary>
        /// <returns> 响应请求的超时时间 </returns>
        public virtual int ResponseTimeout
        {
            get { return responseTimeout; }
            set { responseTimeout = value; }
        }
    }
}