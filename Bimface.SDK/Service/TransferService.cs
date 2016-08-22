using System;
using Bimface.SDK.Bean.Request;
using Bimface.SDK.Bean.Response;
using Bimface.SDK.Configuation;
using Bimface.SDK.Http;
using Bimface.SDK.Utils;

namespace Bimface.SDK.Service
{
    /// <summary>
    ///     文件转换
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class TransferService : AbstractAccessTokenService
    {
        private readonly bool InstanceFieldsInitialized;
        private string GET_TRANSFER_URL;
        private string TRANSFER_URL;

        public TransferService(ServiceClient serviceClient, Endpoint endpoint, AccessTokenService accessTokenService)
            : base(serviceClient, endpoint, accessTokenService)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
        }

        private void InitializeInstanceFields()
        {
            TRANSFER_URL = ApiHost + "/transfer";
            GET_TRANSFER_URL = ApiHost + "/transfer?viewId={0}";
        }

        public virtual TransferBean Transfer(FileTransferRequest fileTransferRequest)
        {
            // 参数校验
            Check(fileTransferRequest);

            var headers = new HttpHeaders();
            headers.AddOAuth2Header(AccessToken);
            var response = ServiceClient.Put(TRANSFER_URL, fileTransferRequest, headers);
            return HttpUtils.Response<TransferBean>(response);
        }

        public virtual TransferBean GetTransfer(string viewId)
        {
            // 参数校验
            AssertUtils.AssertStringNotNullOrEmpty(viewId, "viewId");

            var headers = new HttpHeaders();
            headers.AddOAuth2Header(AccessToken);
            var response = ServiceClient.Get(string.Format(GET_TRANSFER_URL, viewId), headers);
            return HttpUtils.Response<TransferBean>(response);
        }

        private void Check(FileTransferRequest fileTransferRequest)
        {
            AssertUtils.AssertParameterNotNull(fileTransferRequest, "fileTransferRequest");
            if (fileTransferRequest.FileId == null && fileTransferRequest.FileId < 0)
            {
                throw new ArgumentException("ParameterLongIsEmpty FileId");
            }
        }
    }
}