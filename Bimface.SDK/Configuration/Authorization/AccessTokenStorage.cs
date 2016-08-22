using Bimface.SDK.Bean.Response;
using Bimface.SDK.Exceptions;

namespace Bimface.SDK.Configuation.Authorization
{
    /// <summary>
    ///     ����AccessToken�Ľӿڶ���
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public interface AccessTokenStorage
    {
        /// <summary>
        ///     ����accessToken
        /// </summary>
        /// <param name="accessTokenBean">
        ///     <seealso cref="AccessTokenBean" />
        /// </param>
        void Put(AccessTokenBean accessTokenBean);

        /// <summary>
        ///     ��ȡaccessToken
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