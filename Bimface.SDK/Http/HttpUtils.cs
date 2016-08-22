using System;
using System.IO;
using System.Net;
using Bimface.SDK.Bean;
using Bimface.SDK.Exceptions;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Http
{
    /// <summary>
    ///     httpπ§æﬂ¿‡
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class HttpUtils
    {
        public static T Response<T>(HttpWebResponse response)
        {
            var body = "";
            try
            {
                var reader = new StreamReader(response.GetResponseStream());
                body = reader.ReadToEnd();
            }
            catch (IOException e)
            {
                throw new BimfaceException(e);
            }
            var generalResponse = JsonUtils.DeserializeJsonToObject<GeneralResponse<T>>(body);
            if (GeneralResponse<T>.CODE_SUCCESS.Equals(generalResponse.Code, StringComparison.CurrentCultureIgnoreCase))
            {
                return generalResponse.Data;
            }
            throw new BimfaceException(generalResponse.Message, generalResponse.Code);
        }
    }
}