using System.Text;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Http
{
    internal sealed class HttpFormEncodingBuilder
    {
        private readonly StringBuilder builder = new StringBuilder();
        private readonly string contentType = "application/x-www-form-urlencoded";

        internal HttpFormEncodingBuilder()
        {
        }

        internal HttpFormEncodingBuilder(string contentType)
        {
            this.contentType = contentType;
        }

        internal HttpFormEncodingBuilder Add(string name, string value)
        {
            if (builder.Length > 0)
                builder.Append('&');
            builder.Append(string.Format("{0}={1}", name, value));
            return this;
        }

        internal byte[] Build()
        {
            return StringUtils.UTF8Bytes(builder.ToString());
        }
    }
}