using System.IO;
using System.Text;
using System.Web;
using Bimface.SDK.Constants;

namespace Bimface.SDK.Bean.Request
{
    /// <summary>
    ///     文件上传的请求参数
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class FileUploadRequest
    {
        private long contentLength; // 文件长度
        private Stream inputStream; // 文件流
        private string name; // 文件名称，包括后缀名
        private string url; // 文件的下载地址，如果提供了下载地址，则无需设置inputStream、contentLength

        public FileUploadRequest()
        {
        }

        public FileUploadRequest(string name, long contentLength, Stream inputStream)
        {
            this.name = name;
            this.contentLength = contentLength;
            this.inputStream = inputStream;
        }

        public FileUploadRequest(string name, string url)
        {
            this.name = name;
            this.url = url;
        }

        public virtual string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public virtual long ContentLength
        {
            get { return contentLength; }
            set { contentLength = value; }
        }

        public virtual string Url
        {
            get { return url; }
            set
            {
                if (value == null)
                {
                    return;
                }
                try
                {
                    url = HttpUtility.UrlEncode(value, Encoding.GetEncoding(BimfaceConstants.UTF_8));
                }
                catch (EncoderFallbackException)
                {
                    // ignore
                }
            }
        }

        public virtual Stream InputStream
        {
            get { return inputStream; }
            set { inputStream = value; }
        }

        /// <summary>
        ///     判断是否通过URL方式上传文件
        /// </summary>
        /// <returns> true:是, false:否 </returns>
        public virtual bool ByUrl
        {
            get { return url != null; }
        }

        public override string ToString()
        {
            return string.Format(
                "FileUploadRequest [name={0}, contentLength={1}, url={2}, inputStream={3}]", name,
                contentLength, url, inputStream);
        }
    }
}