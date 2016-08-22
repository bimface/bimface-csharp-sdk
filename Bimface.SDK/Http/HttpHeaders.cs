using System.Net;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Http
{
    /// <summary>
    ///     HTTP headers 工具
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class HttpHeaders : WebHeaderCollection
    {
        public const string AUTHORIZATION = "Authorization";
        public const string CACHE_CONTROL = "Cache-Control";
        public const string CONTENT_DISPOSITION = "Content-Disposition";
        public const string CONTENT_ENCODING = "Content-Encoding";
        public const string CONTENT_LENGTH = "Content-Length";
        public const string CONTENT_MD5 = "Content-MD5";
        public const string CONTENT_TYPE = "Content-Type";
        public const string TRANSFER_ENCODING = "Transfer-Encoding";
        public const string DATE = "Date";
        public const string ETAG = "ETag";
        public const string EXPIRES = "Expires";
        public const string HOST = "Host";
        public const string LAST_MODIFIED = "Last-Modified";
        public const string RANGE = "Range";
        public const string LOCATION = "Location";
        public const string CONNECTION = "Connection";

        /// <summary>
        ///     header里添加授权Authorization的Basic认证
        /// </summary>
        /// <param name="appKey"> bimface颁发授权的应用key </param>
        /// <param name="appSecret"> bimface颁发授权的应用secret </param>
        public virtual void AddBasicAuthHeader(string appKey, string appSecret)
        {
            var bytes = StringUtils.UTF8Bytes(appKey + ":" + appSecret);
            var credential = "Basic " + Base64.Encode(bytes);
            Add(AUTHORIZATION, credential.Replace("\n", "").Replace("\r", ""));
        }

        /// <summary>
        ///     header里添加授权Authorization的Bearer认证
        /// </summary>
        /// <param name="token"> 由bimface颁发的appKey和appSecret通过Basic认证获取的token </param>
        public virtual void AddOAuth2Header(string token)
        {
            Add(AUTHORIZATION, "Bearer " + token);
        }
    }
}