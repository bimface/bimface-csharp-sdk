using Bimface.SDK.Constants;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Configuation
{
    /// <summary>
    ///     ����
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
        ///     ��ȡ�����ã��û�����
        /// </summary>
        /// <returns> �û����� </returns>
        public virtual string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }

        /// <summary>
        ///     ��ȡ�����ã�������������
        /// </summary>
        /// <returns> ������������ </returns>
        public virtual int MaxIdleConnections
        {
            get { return maxIdleConnections; }
            set { maxIdleConnections = value; }
        }

        /// <summary>
        ///     ��ȡ�����ã����ֻ����ʱ��
        /// </summary>
        /// <returns> ���ֻ����ʱ������λ�����룩 </returns>
        public virtual long KeepAliveDurationNs
        {
            get { return keepAliveDurationNs; }
            set { keepAliveDurationNs = value; }
        }

        /// <summary>
        ///     ��ȡ�����ã�����򿪵����������
        /// </summary>
        /// <returns> ��������� </returns>
        public virtual int MaxRequests
        {
            get { return maxRequests; }
            set { maxRequests = value; }
        }

        /// <summary>
        ///     ��ȡ�����ã�ÿ̨��������������
        /// </summary>
        /// <returns> ÿ̨�������������� </returns>
        public virtual int MaxRequestsPerHost
        {
            get { return maxRequestsPerHost; }
            set { maxRequestsPerHost = value; }
        }

        /// <summary>
        ///     ��ȡ�����ã��������ӵĳ�ʱʱ�䣨��λ���룩
        /// </summary>
        /// <returns> �������ӵĳ�ʱʱ�䣨��λ���룩 </returns>
        public virtual int ConnectTimeout
        {
            get { return connectTimeout; }
            set { connectTimeout = value; }
        }

        /// <summary>
        ///     ��ȡ�����ã���ȡ��Ӧ�ĳ�ʱʱ��
        /// </summary>
        /// <returns> ��ȡ��Ӧ�ĳ�ʱʱ�� </returns>
        public virtual int ReadWriteTimeout
        {
            get { return readWriteWriteTimeout; }
            set { readWriteWriteTimeout = value; }
        }

        /// <summary>
        ///     ��ȡ�����ã�д������ĳ�ʱʱ��
        /// </summary>
        /// <returns> д������ĳ�ʱʱ�� </returns>
        public virtual int WriteTimeout
        {
            get { return writeTimeout; }
            set { writeTimeout = value; }
        }

        /// <summary>
        ///     ��ȡ�����ã���Ӧ����ĳ�ʱʱ��
        /// </summary>
        /// <returns> ��Ӧ����ĳ�ʱʱ�� </returns>
        public virtual int ResponseTimeout
        {
            get { return responseTimeout; }
            set { responseTimeout = value; }
        }
    }
}