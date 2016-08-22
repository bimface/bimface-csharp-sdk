using System.IO;
using System.Text;
using System.Web;
using Bimface.SDK.Constants;

namespace Bimface.SDK.Bean.Request
{
    /// <summary>
    ///     �ļ��ϴ����������
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class FileUploadRequest
    {
        private long contentLength; // �ļ�����
        private Stream inputStream; // �ļ���
        private string name; // �ļ����ƣ�������׺��
        private string suffix; // �ļ���׺��
        private string url; // �ļ������ص�ַ������ṩ�����ص�ַ������������inputStream��contentLength

        public FileUploadRequest()
        {
        }

        public FileUploadRequest(string name, long contentLength, Stream inputStream)
        {
            this.name = name;
            if (name != null && name.Length > 0)
            {
                Suffix = name.Substring(name.LastIndexOf(".") + 1, name.Length - (name.LastIndexOf(".") + 1));
            }
            this.contentLength = contentLength;
            this.inputStream = inputStream;
        }

        public FileUploadRequest(string name, string url)
        {
            this.name = name;
            if (name != null && name.Length > 0)
            {
                Suffix = name.Substring(name.LastIndexOf(".") + 1, name.Length - (name.LastIndexOf(".") + 1));
            }
            this.url = url;
        }

        public virtual string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (value != null && value.Length > 0)
                {
                    Suffix = value.Substring(value.LastIndexOf(".") + 1, value.Length - (value.LastIndexOf(".") + 1));
                }
            }
        }

        public virtual string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
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
        ///     �ж��Ƿ�ͨ��URL��ʽ�ϴ��ļ�
        /// </summary>
        /// <returns> true:��, false:�� </returns>
        public virtual bool ByUrl
        {
            get { return url != null; }
        }

        public override string ToString()
        {
            return string.Format(
                "FileUploadRequest [name={0}, suffix={1}, contentLength={2}, url={3}, inputStream={4}]", name, suffix,
                contentLength, url, inputStream);
        }
    }
}