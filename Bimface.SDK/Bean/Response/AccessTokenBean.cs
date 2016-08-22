namespace Bimface.SDK.Bean.Response
{
    /// <summary>
    ///     AccessToken�ķ��ز���
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class AccessTokenBean
    {
        private string expireTime; // AccessToken��ʧЧʱ�䣬��ʽ��yyyy-MM-dd hh:mm:ss
        private string token; // AccessToken

        public virtual string Token
        {
            get { return token; }
            set { token = value; }
        }

        public virtual string ExpireTime
        {
            get { return expireTime; }
            set { expireTime = value; }
        }

        public override string ToString()
        {
            return string.Format("AccessTokenBean [token={0}, expireTime={1}]", token, expireTime);
        }
    }
}