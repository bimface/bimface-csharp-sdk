using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Bimface.SDK.Configuation;
using Bimface.SDK.Constants;
using Bimface.SDK.Exceptions;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Http
{
    /// <summary>
    ///     API请求的Client
    ///     \n
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class ServiceClient
    {
        private readonly Config httpConfig;

        public ServiceClient()
        {
            httpConfig = new Config();
        }

        public ServiceClient(Config config)
        {
            httpConfig = config;
        }

        /// <summary>
        ///     空内容
        /// </summary>
        public string EmptyRequestBody
        {
            get { return string.Empty; }
        }

        public virtual HttpWebResponse Get(string url)
        {
            return Get(url, new HttpHeaders());
        }

        public virtual HttpWebResponse Get(string url, HttpHeaders headers)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            if (headers != null)
                request.Headers = headers;
            request.Method = WebRequestMethods.Http.Get;
            return Send(request, new byte[0]);
        }

        public virtual HttpWebResponse Post(string url, byte[] body, HttpHeaders headers)
        {
            return Post(url, body, headers, BimfaceConstants.STREAM_MIME);
        }

        public virtual HttpWebResponse Post(string url, string body, HttpHeaders headers)
        {
            return Post(url, body, headers, BimfaceConstants.STREAM_MIME);
        }

        public virtual HttpWebResponse Post(string url, HttpFormEncoding @params, HttpHeaders headers)
        {
            var builder = new HttpFormEncodingBuilder();
            foreach (var key in @params.Params.Keys)
                builder.Add(key, @params.Params[key]);
            return Post(url, builder.Build(), headers);
        }

        public virtual HttpWebResponse Post(string url, string body, HttpHeaders headers, string contentType)
        {
            var bodyContent = new byte[0];
            if (!string.IsNullOrEmpty(body))
                bodyContent = Encoding.UTF8.GetBytes(body);
            return Post(url, bodyContent, headers, contentType);
        }

        public virtual HttpWebResponse Post(string url, byte[] body, int offset, int size, HttpHeaders headers,
            string contentType)
        {
            var bodyContent = new byte[0];
            if (body != null && body.Length > 0)
            {
                bodyContent = new byte[size];
                body.CopyTo(bodyContent, offset);
            }
            return Post(url, bodyContent, headers, contentType);
        }

        public virtual HttpWebResponse Post(string url, Stream inputStream, long contentLength, HttpHeaders headers)
        {
            if (contentLength > BimfaceConstants.PUT_THRESHOLD)
            {
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                if (headers != null)
                    request.Headers = headers;
                request.MediaType = BimfaceConstants.JSON_MIME;
                request.ContentType = BimfaceConstants.JSON_MIME;
                request.Method = WebRequestMethods.Http.Post;
                return Send(request, inputStream, contentLength);
            }
            var buffer = new byte[contentLength];
            inputStream.Read(buffer, 0, (int) contentLength);
            return Post(url, buffer, headers);
        }

        private HttpWebResponse Post(string url, byte[] body, HttpHeaders headers, string contentType)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            if (headers != null)
                request.Headers = headers;
            request.MediaType = contentType;
            request.ContentType = contentType;
            request.Method = WebRequestMethods.Http.Post;
            return Send(request, body);
        }

        public HttpWebResponse Put(string url, HttpHeaders headers)
        {
            return Put(url, string.Empty, headers);
        }

        public virtual HttpWebResponse Put(string url, object body, HttpHeaders headers)
        {
            return Put(url, JsonUtils.SerializeObject(body), headers);
        }

        public virtual HttpWebResponse Put(string url, string body, HttpHeaders headers)
        {
            var bodyContent = new byte[0];
            if (!string.IsNullOrEmpty(body))
                bodyContent = Encoding.UTF8.GetBytes(body);
            return Put(url, bodyContent, headers);
        }

        public virtual HttpWebResponse Put(string url, Stream inputStream, long contentLength, HttpHeaders headers)
        {
            if (contentLength > BimfaceConstants.PUT_THRESHOLD)
            {
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                if (headers != null)
                    request.Headers = headers;
                request.MediaType = BimfaceConstants.JSON_MIME;
                request.ContentType = BimfaceConstants.JSON_MIME;
                request.Method = WebRequestMethods.Http.Put;
                return Send(request, inputStream, contentLength);
            }
            var buffer = new byte[contentLength];
            inputStream.Read(buffer, 0, (int) contentLength);
            return Put(url, buffer, headers);
        }

        private HttpWebResponse Put(string url, byte[] body, HttpHeaders headers)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            if (headers != null)
                request.Headers = headers;
            request.MediaType = BimfaceConstants.MEDIA_TYPE_JSON;
            request.ContentType = BimfaceConstants.JSON_MIME;
            request.Method = WebRequestMethods.Http.Put;
            return Send(request, body);
        }

        public virtual HttpWebResponse Delete(string url)
        {
            return Delete(url, new HttpHeaders());
        }

        public virtual HttpWebResponse Delete(string url, HttpHeaders headers)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            if (headers != null)
                request.Headers = headers;
            request.Method = "DELETE";
            return Send(request, new byte[0]);
        }

        public virtual HttpWebResponse Send(HttpWebRequest request, byte[] body)
        {
            request.ContentLength = body.Length;
            try
            {
                SetRequestConfig(request);
                request.UserAgent = VersionInfoUtils.DefaultUserAgent;
                if (body != null && body.Length > 0)
                {
                    var requestStream = request.GetRequestStream();
                    requestStream.Write(body, 0, body.Length);
                    requestStream.Close();
                }
                var response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode >= (HttpStatusCode) 300)
                    throw new BimfaceException(response.StatusDescription,
                        Enum.GetName(typeof (HttpStatusCode), response.StatusCode));
                return response;
            }
            catch (IOException e)
            {
                throw new BimfaceException(e);
            }
        }

        public virtual HttpWebResponse Send(HttpWebRequest request, Stream body, long contentLength)
        {
            request.ContentLength = contentLength;
            try
            {
                SetRequestConfig(request);
                request.UserAgent = VersionInfoUtils.DefaultUserAgent;
                request.AllowWriteStreamBuffering = false;
                var contentLeft = contentLength;
                var requestStream = request.GetRequestStream();
                var content = new StringBuilder();
                while (contentLeft > 0)
                {
                    var length = contentLeft > BimfaceConstants.PUT_THRESHOLD
                        ? BimfaceConstants.PUT_THRESHOLD
                        : (int) contentLeft;
                    var buffer = new byte[length];
                    body.Read(buffer, 0, length);
                    requestStream.Write(buffer, 0, length);
                    contentLeft -= length;
                    content.Append(Encoding.Unicode.GetString(buffer));
                }
                requestStream.Close();
                var response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode >= (HttpStatusCode) 300)
                    throw new BimfaceException(response.StatusDescription,
                        Enum.GetName(typeof (HttpStatusCode), response.StatusCode));
                return response;
            }
            catch (IOException e)
            {
                throw new BimfaceException(e);
            }
        }

        private void SetRequestConfig(HttpWebRequest request)
        {
            request.Timeout = httpConfig.ResponseTimeout;
            request.ReadWriteTimeout = httpConfig.ReadWriteTimeout;
        }
    }
}