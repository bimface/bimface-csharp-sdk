using System.Collections.Generic;

namespace Bimface.SDK.Http
{
    /// <summary>
    ///     x-www-form-urlencoded表单提交的参数
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class HttpFormEncoding
    {
        private IDictionary<string, string> @params = new Dictionary<string, string>();

        public virtual IDictionary<string, string> Params
        {
            get { return @params; }
            set { @params = value; }
        }

        /// <summary>
        ///     追加参数
        /// </summary>
        /// <param name="key"> Key </param>
        /// <param name="value"> Value </param>
        public virtual void AddParams(string key, string value)
        {
            @params[key] = value;
        }
    }
}