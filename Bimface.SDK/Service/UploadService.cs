using System;
using System.Net;
using Bimface.SDK.Bean.Request;
using Bimface.SDK.Bean.Response;
using Bimface.SDK.Configuation;
using Bimface.SDK.Http;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     文件上传
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class UploadService : AbstractAccessTokenService
    {
        private readonly bool InstanceFieldsInitialized;
        private string UPLOAD_BY_URL_URL;
        private string UPLOAD_URL;

        public UploadService(ServiceClient serviceClient, Endpoint endpoint, AccessTokenService accessTokenService)
            : base(serviceClient, endpoint, accessTokenService)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
        }

        public virtual SupportFileService SupportFileService { set; get; }

        private void InitializeInstanceFields()
        {
            UPLOAD_URL = FileHost + "/upload?name={0}";
            UPLOAD_BY_URL_URL = FileHost + "/upload?name={0}&url={2}";
        }

        public virtual FileBean Upload(FileUploadRequest fileUploadRequest)
        {
            // 参数校验
            Check(fileUploadRequest);

            var headers = new HttpHeaders();
            headers.AddOAuth2Header(AccessToken);
            HttpWebResponse response = null;
            string requestUrl = null;
            if (fileUploadRequest.ByUrl)
            {
                requestUrl = string.Format(UPLOAD_BY_URL_URL, fileUploadRequest.Name,
                    fileUploadRequest.Url);
                response = ServiceClient.Put(requestUrl, headers);
            }
            else
            {
                requestUrl = string.Format(UPLOAD_URL, fileUploadRequest.Name);
                //headers.Add(HttpHeaders.CONTENT_LENGTH, fileUploadRequest.ContentLength.ToString());
                response = ServiceClient.Put(requestUrl, fileUploadRequest.InputStream, fileUploadRequest.ContentLength,
                    headers);
            }
            return HttpUtils.Response<FileBean>(response);
        }

        private void Check(FileUploadRequest fileUploadRequest)
        {
            AssertUtils.AssertParameterNotNull(fileUploadRequest, "fileUploadRequest");
            if (fileUploadRequest.Url == null)
            {
                if (fileUploadRequest.ContentLength <= 0)
                {
                    throw new ArgumentException("ParameterLongIsEmpty ContentLength");
                }
                AssertUtils.AssertParameterNotNull(fileUploadRequest.InputStream, "inputStream");
            }
            FileNameUtils.CheckFileName(fileUploadRequest.Name);
            SupportFileBean supportFile = SupportFileService.GetSupport;
            FileNameUtils.CheckFileType(supportFile.Types, fileUploadRequest.Name);
        }
    }
}