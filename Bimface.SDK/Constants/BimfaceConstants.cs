namespace Bimface.SDK.Constants
{
    /// <summary>
    ///     常量
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class BimfaceConstants
    {
        // API服务器地址
        public const string API_HOST = "https://api.bimface.com";
        // 文件上传API服务器地址
        public const string FILE_HOST = "https://file.bimface.com";
        public const string STREAM_MIME = "application/octet-stream";
        public const string JSON_MIME = "application/json";
        public const string FORM_MIME = "application/x-www-form-urlencoded";
        // 断点上传时的分块大小(默认的分块大小, 不允许改变)
        public const int BLOCK_SIZE = 4*1024*1024;
        // 最大空闲连接数
        public const int DEFAULT_MAX_IDLE_CONNECTIONS = 32;
        // 保持活动周期时长
        public const long DEFAULT_KEEP_ALIVE_DURATION_NS = 5*60*1000;
        // 最大请求数
        public const int DEFAULT_MAX_REQUESTS = 64;
        // 每台主机最大的请求数
        public const int DEFAULT_MAX_REQUESTS_PER_HOST = 5;
        // 连接超时时间 单位秒(默认10000 ms)
        public const int DEFAULT_CONNECT_TIMEOUT = 100000;
        // 写超时时间 单位秒(默认 0 ms , 不超时)
        public const int DEFAULT_WRITE_TIMEOUT = 0;
        // 读写超时时间 单位秒(默认 0 ms , 不超时)
        public const int DEFAULT_READ_WRITE_TIMEOUT = 100000;
        // 回复超时时间 单位秒(默认30000 ms)
        public const int DEFAULT_RESPONSE_TIMEOUT = 30000;
        // 默认字符集编码
        public static readonly int UTF_8 = 65001;
        public static readonly string MEDIA_TYPE_JSON = "application/json; charset=utf-8";
        // 如果文件大小大于此值则使用断点上传, 否则使用Form上传
        public static int PUT_THRESHOLD = BLOCK_SIZE;
    }
}