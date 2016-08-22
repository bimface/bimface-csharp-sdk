using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bimface.SDK.Utils
{
    public class RequestRecord : Stack<KeyValuePair<HttpWebRequest, string>>
    {
        private RequestRecord() : base()
        {

        }

        public static readonly RequestRecord Instance = new RequestRecord();
    }
}
