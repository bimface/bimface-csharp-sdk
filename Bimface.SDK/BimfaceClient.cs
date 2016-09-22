using System.Collections.Generic;
using System.IO;
using Bimface.SDK.Bean.Request;
using Bimface.SDK.Bean.Response;
using Bimface.SDK.Configuation;
using Bimface.SDK.Configuation.Authorization;
using Bimface.SDK.Exceptions;
using Bimface.SDK.Http;
using Bimface.SDK.Service;

namespace Bimface.SDK
{
    /// <summary>
    ///     访问Bimface服务的入口
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class BimfaceClient
    {
        private readonly AccessTokenService accessTokenService;
        private readonly Credential credential; // APP证书
        private readonly Endpoint endpoint; // API调用地址入口
        private readonly ServiceClient serviceClient; // API请求的Client
        private readonly ShareLinkService shareLinkService;
        private readonly SignatureService signatureService;
        private readonly SupportFileService supportFileService;
        private readonly TransferService transferService;
        private readonly UploadService uploadService;
        private readonly ViewTokenService viewTokenService;

        /// <summary>
        ///     构造BimfaceClient对象
        /// </summary>
        /// <param name="appKey"> AppKey </param>
        /// <param name="appSecret"> AppSecret </param>
        public BimfaceClient(string appKey, string appSecret) : this(appKey, appSecret, null, null, null)
        {
        }

        /// <summary>
        ///     构造BimfaceClient对象
        /// </summary>
        /// <param name="appKey"> AppKey </param>
        /// <param name="appSecret"> AppSecret </param>
        /// <param name="config"> 参数配置 </param>
        public BimfaceClient(string appKey, string appSecret, Config config)
            : this(appKey, appSecret, null, config, null)
        {
        }

        /// <summary>
        ///     构造BimfaceClient对象
        /// </summary>
        /// <param name="appKey"> AppKey </param>
        /// <param name="appSecret"> AppSecret </param>
        /// <param name="endpoint"> API调用地址入口 </param>
        /// <param name="config"> 参数配置 </param>
        public BimfaceClient(string appKey, string appSecret, Endpoint endpoint, Config config)
            : this(appKey, appSecret, endpoint, config, null)
        {
        }

        /// <summary>
        ///     构造BimfaceClient对象
        /// </summary>
        /// <param name="appKey"> AppKey </param>
        /// <param name="appSecret"> AppSecret </param>
        /// <param name="endpoint"> API调用地址入口 </param>
        /// <param name="config"> 参数配置 </param>
        /// <param name="accessTokenStorage"> AccessToken的缓存方式 </param>
        public BimfaceClient(string appKey, string appSecret, Endpoint endpoint, Config config,
            AccessTokenStorage accessTokenStorage)
        {
            // 初始化APP证书
            credential = new Credential(appKey, appSecret);

            // 初始化API调用地址入口
            if (endpoint == null)
            {
                this.endpoint = new Endpoint();
            }
            else
            {
                this.endpoint = endpoint;
            }

            // 初始化API请求的Client
            if (config == null)
            {
                serviceClient = new ServiceClient(new Config());
            }
            else
            {
                serviceClient = new ServiceClient(config);
            }

            // 初始化缓存AccessToken的方式
            AccessTokenStorage usedAccessTokenStorage = null;
            if (accessTokenStorage == null)
            {
                usedAccessTokenStorage = new DefaultAccessTokenStorage();
            }
            else
            {
                usedAccessTokenStorage = accessTokenStorage;
            }

            // 初始化Service
            accessTokenService = new AccessTokenService(serviceClient, this.endpoint, credential, usedAccessTokenStorage);
            supportFileService = new SupportFileService(serviceClient, this.endpoint, accessTokenService);
            uploadService = new UploadService(serviceClient, this.endpoint, accessTokenService);
            uploadService.SupportFileService = supportFileService;
            transferService = new TransferService(serviceClient, this.endpoint, accessTokenService);
            viewTokenService = new ViewTokenService(serviceClient, this.endpoint, accessTokenService);
            shareLinkService = new ShareLinkService(serviceClient, this.endpoint, accessTokenService);
            signatureService = new SignatureService(credential);
        }

        /// <summary>
        ///     获取支持的文件格式
        /// </summary>
        /// <returns> 文件后缀名数组 </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual SupportFileBean GetSupport
        {
            get { return supportFileService.GetSupport; }
        }

        public virtual Credential Credential
        {
            get { return credential; }
        }

        public virtual Endpoint Endpoint
        {
            get { return endpoint; }
        }

        public virtual ServiceClient ServiceClient
        {
            get { return serviceClient; }
        }

        public virtual AccessTokenService AccessTokenService
        {
            get { return accessTokenService; }
        }

        public virtual SupportFileService SupportFileService
        {
            get { return supportFileService; }
        }

        public virtual UploadService UploadService
        {
            get { return uploadService; }
        }

        public virtual TransferService TransferService
        {
            get { return transferService; }
        }

        public virtual ViewTokenService ViewTokenService
        {
            get { return viewTokenService; }
        }

        public virtual ShareLinkService ShareLinkService
        {
            get { return shareLinkService; }
        }

        public virtual SignatureService SignatureService
        {
            get { return signatureService; }
        }

        /// <summary>
        ///     上传文件
        /// </summary>
        /// <param name="fileUploadRequest">
        ///     <seealso cref="FileUploadRequest" />
        /// </param>
        /// <returns>
        ///     <seealso cref="FileBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual FileBean Upload(FileUploadRequest fileUploadRequest)
        {
            return uploadService.Upload(fileUploadRequest);
        }

        /// <summary>
        ///     上传文件,文件流方式
        /// </summary>
        /// <param name="name"> 文件名 </param>
        /// <param name="contentLength"> 文件长度 </param>
        /// <param name="inputStream"> 文件流 </param>
        /// <returns>
        ///     <seealso cref="FileBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual FileBean Upload(string name, int contentLength, Stream inputStream)
        {
            return uploadService.Upload(new FileUploadRequest(name, contentLength, inputStream));
        }

        /// <summary>
        ///     上传文件,URL方式
        /// </summary>
        /// <param name="name"> 文件名 </param>
        /// <param name="url"> 文件下载地址 </param>
        /// <returns>
        ///     <seealso cref="FileBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual FileBean Upload(string name, string url)
        {
            return uploadService.Upload(new FileUploadRequest(name, url));
        }

        /// <summary>
        ///     发起文件转换
        /// </summary>
        /// <param name="fileTransferRequest">
        ///     <seealso cref="FileTransferRequest" />
        /// </param>
        /// <returns>
        ///     <seealso cref="TransferBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual TransferBean Transfer(FileTransferRequest fileTransferRequest)
        {
            return transferService.Transfer(fileTransferRequest);
        }

        /// <summary>
        ///     发起文件转换,不设置callback地址
        /// </summary>
        /// <param name="fileId"> 文件ID </param>
        /// <returns>
        ///     <seealso cref="TransferBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual TransferBean Transfer(long? fileId)
        {
            return transferService.Transfer(new FileTransferRequest(fileId));
        }

        /// <summary>
        ///     发起文件转换,设置callback地址
        /// </summary>
        /// <param name="fileId"> 文件ID </param>
        /// <param name="callback"> 回调地址 </param>
        /// <returns>
        ///     <seealso cref="TransferBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual TransferBean Transfer(long? fileId, string callback)
        {
            return transferService.Transfer(new FileTransferRequest(fileId, callback));
        }

        /// <summary>
        ///     获取文件转换状态
        /// </summary>
        /// <param name="transferId"> 转换ID </param>
        /// <returns>
        ///     <seealso cref="TransferBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual TransferBean GetTransfer(string transferId)
        {
            return transferService.GetTransfer(transferId);
        }

        /// <summary>
        ///     获取viewToken, 用于模型预览的凭证
        /// </summary>
        /// <param name="transferId"> 转换ID </param>
        /// <returns> viewToken </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual string GetViewToken(string transferId)
        {
            return viewTokenService.GrantViewToken(transferId);
        }

        /// <summary>
        ///     创建分享链接
        /// </summary>
        /// <param name="transferId"> 转换ID </param>
        /// <param name="activeHours"> 从当前算起，分享链接的有效时间，单位：小时; 如果为空，表示该分享链接永久有效 </param>
        /// <returns>
        ///     <seealso cref="ShareLinkBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual ShareLinkBean CreateShareLink(string transferId, int? activeHours)
        {
            return shareLinkService.Create(transferId, activeHours);
        }

        /// <summary>
        ///     创建分享链接,永久有效
        /// </summary>
        /// <param name="transferId"> 转换ID </param>
        /// <returns>
        ///     <seealso cref="ShareLinkBean" />
        /// </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual ShareLinkBean CreateShareLink(string transferId)
        {
            return shareLinkService.Create(transferId);
        }

        /// <summary>
        ///     删除分享链接
        /// </summary>
        /// <param name="transferId"> 转换ID </param>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual void DeleteShareLink(string transferId)
        {
            shareLinkService.Delete(transferId);
        }

        /// <summary>
        ///     验证签名, 接收转换回调时使用
        /// </summary>
        /// <param name="signature"> 签名字符 </param>
        /// <param name="transferId"> 转换ID </param>
        /// <param name="status"> 转换状态(success || failed) </param>
        /// <returns> true: 验证成功, false: 校验失败 </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual bool ValidateSignature(string signature, string transferId, string status, string nonce)
        {
            return signatureService.Validate(signature, transferId, status, nonce);
        }
    }
}