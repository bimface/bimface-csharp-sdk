namespace Bimface.SDK.Bean.Response
{
    /// <summary>
    ///     �������ӵķ��ز���
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class ShareLinkBean
    {
        private string expireTime; // �������ӵĹ���ʱ�䣬��ʽ��yyyy-MM-dd hh:mm:ss
        private string url; // �������ӵ�URL

        public ShareLinkBean()
        {
        }

        public ShareLinkBean(string url, string expireTime)
        {
            this.url = url;
            this.expireTime = expireTime;
        }

        public virtual string Url
        {
            get { return url; }
            set { url = value; }
        }

        public virtual string ExpireTime
        {
            get { return expireTime; }
            set { expireTime = value; }
        }

        public override string ToString()
        {
            return string.Format("ShareLinkBean [url={0}, expireTime={1}]", url, expireTime);
        }
    }
}