using System;

namespace Bimface.SDK.Exceptions
{
    /// <summary>
    ///     bimface统一返回的异常
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class BimfaceException : Exception
    {
        private const long serialVersionUID = 2192833742497163711L;
        private readonly string errorCode;
        private readonly int httpCode;

        public BimfaceException(Exception e)
        {
        }

        public BimfaceException(string message) : base(message)
        {
        }

        public BimfaceException(string message, int httpCode) : this(message)
        {
            this.httpCode = httpCode;
        }

        public BimfaceException(string message, string errorCode) : this(message)
        {
            this.errorCode = errorCode;
        }

        public virtual int HttpCode
        {
            get { return httpCode; }
        }

        public virtual string ErrorCode
        {
            get { return errorCode; }
        }
    }
}