using Bimface.SDK.Bean.Response;
using Bimface.SDK.Exceptions;

namespace Bimface.SDK.Configuation.Authorization
{
    /// <summary>
    ///     缓存AccessToken的接口定义
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public interface AccessTokenStorage
    {
        /// <summary>
        ///     保存accessToken
        /// </summary>
        /// <param name="accessTokenBean">
        ///     <seealso cref="AccessTokenBean" />
        /// </param>
        void Put(AccessTokenBean accessTokenBean);

        /// <summary>
        ///     获取accessToken
        /// </summary>
        /// <returns>
        ///     <seealso cref="AccessTokenBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        AccessTokenBean Get();
    }
}