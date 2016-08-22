using System;

namespace Bimface.SDK.Configuation.Authorization
{
    /// <summary>
    ///     APP证书
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public sealed class Credential
    {
        public Credential(string appKey, string appSecret)
        {
            Check(appKey, appSecret);
            AppKey = appKey;
            AppSecret = appSecret;
        }

        public string AppKey { get; set; }
        public string AppSecret { get; set; }

        private void Check(string appKey, string appSecret)
        {
            if (appKey == null || appKey.Equals(""))
            {
                throw new ArgumentException("appKey should not be null or empty.");
            }
            if (appSecret == null || appSecret.Equals(""))
            {
                throw new ArgumentException("appSecret should not be null or empty.");
            }
        }
    }
}