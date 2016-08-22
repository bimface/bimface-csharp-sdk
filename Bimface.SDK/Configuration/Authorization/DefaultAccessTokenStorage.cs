using System;
using System.Globalization;
using Bimface.SDK.Bean.Response;
using Bimface.SDK.Exceptions;

namespace Bimface.SDK.Configuation.Authorization
{
    /// <summary>
    ///     Ĭ������£�����AccessToken�ķ�ʽ
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class DefaultAccessTokenStorage : AccessTokenStorage
    {
        private AccessTokenBean accessTokenBean;

        public virtual void Put(AccessTokenBean accessTokenBean)
        {
            lock (this)
            {
                this.accessTokenBean = accessTokenBean;
            }
        }

        public virtual AccessTokenBean Get()
        {
            if (accessTokenBean == null)
            {
                return null;
            }
            if (HasExpired(accessTokenBean.ExpireTime))
            {
                return null;
            }
            return accessTokenBean;
        }

        /// <summary>
        ///     �ж��Ƿ���ڻ򼴽�����
        /// </summary>
        /// <param name="expireTime"> ����ʱ�� </param>
        /// <returns> true:�ѹ��ڻ򼴽�����, false:δ���� </returns>
        /// <exception cref="BimfaceException"> <seealso cref="BimfaceException" />�쳣 </exception>
        private bool HasExpired(string expireTime)
        {
            if (string.IsNullOrEmpty(expireTime))
                return true;
            var expire = DateTime.ParseExact(expireTime, "yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            if (expire == null)
                return true;
            return (expire.Ticks - (DateTime.Now).Ticks) <= 1000;
        }
    }
}