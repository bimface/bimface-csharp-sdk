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
    ///     ����Bimface��������
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class BimfaceClient
    {
        private readonly AccessTokenService accessTokenService;
        private readonly Credential credential; // APP֤��
        private readonly Endpoint endpoint; // API���õ�ַ���
        private readonly ServiceClient serviceClient; // API�����Client
        private readonly ShareLinkService shareLinkService;
        private readonly SignatureService signatureService;
        private readonly SupportFileService supportFileService;
        private readonly TransferService transferService;
        private readonly UploadService uploadService;
        private readonly ViewTokenService viewTokenService;

        /// <summary>
        ///     ����BimfaceClient����
        /// </summary>
        /// <param name="appKey"> AppKey </param>
        /// <param name="appSecret"> AppSecret </param>
        public BimfaceClient(string appKey, string appSecret) : this(appKey, appSecret, null, null, null)
        {
        }

        /// <summary>
        ///     ����BimfaceClient����
        /// </summary>
        /// <param name="appKey"> AppKey </param>
        /// <param name="appSecret"> AppSecret </param>
        /// <param name="config"> �������� </param>
        public BimfaceClient(string appKey, string appSecret, Config config)
            : this(appKey, appSecret, null, config, null)
        {
        }

        /// <summary>
        ///     ����BimfaceClient����
        /// </summary>
        /// <param name="appKey"> AppKey </param>
        /// <param name="appSecret"> AppSecret </param>
        /// <param name="endpoint"> API���õ�ַ��� </param>
        /// <param name="config"> �������� </param>
        public BimfaceClient(string appKey, string appSecret, Endpoint endpoint, Config config)
            : this(appKey, appSecret, endpoint, config, null)
        {
        }

        /// <summary>
        ///     ����BimfaceClient����
        /// </summary>
        /// <param name="appKey"> AppKey </param>
        /// <param name="appSecret"> AppSecret </param>
        /// <param name="endpoint"> API���õ�ַ��� </param>
        /// <param name="config"> �������� </param>
        /// <param name="accessTokenStorage"> AccessToken�Ļ��淽ʽ </param>
        public BimfaceClient(string appKey, string appSecret, Endpoint endpoint, Config config,
            AccessTokenStorage accessTokenStorage)
        {
            // ��ʼ��APP֤��
            credential = new Credential(appKey, appSecret);

            // ��ʼ��API���õ�ַ���
            if (endpoint == null)
            {
                this.endpoint = new Endpoint();
            }
            else
            {
                this.endpoint = endpoint;
            }

            // ��ʼ��API�����Client
            if (config == null)
            {
                serviceClient = new ServiceClient(new Config());
            }
            else
            {
                serviceClient = new ServiceClient(config);
            }

            // ��ʼ������AccessToken�ķ�ʽ
            AccessTokenStorage usedAccessTokenStorage = null;
            if (accessTokenStorage == null)
            {
                usedAccessTokenStorage = new DefaultAccessTokenStorage();
            }
            else
            {
                usedAccessTokenStorage = accessTokenStorage;
            }

            // ��ʼ��Service
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
        ///     ��ȡ֧�ֵ��ļ���ʽ
        /// </summary>
        /// <returns> �ļ���׺������ </returns>
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
        ///     �ϴ��ļ�
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
        ///     �ϴ��ļ�,�ļ�����ʽ
        /// </summary>
        /// <param name="name"> �ļ��� </param>
        /// <param name="contentLength"> �ļ����� </param>
        /// <param name="inputStream"> �ļ��� </param>
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
        ///     �ϴ��ļ�,URL��ʽ
        /// </summary>
        /// <param name="name"> �ļ��� </param>
        /// <param name="url"> �ļ����ص�ַ </param>
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
        ///     �����ļ�ת��
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
        ///     �����ļ�ת��,������callback��ַ
        /// </summary>
        /// <param name="fileId"> �ļ�ID </param>
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
        ///     �����ļ�ת��,����callback��ַ
        /// </summary>
        /// <param name="fileId"> �ļ�ID </param>
        /// <param name="callback"> �ص���ַ </param>
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
        ///     ��ȡ�ļ�ת��״̬
        /// </summary>
        /// <param name="transferId"> ת��ID </param>
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
        ///     ��ȡviewToken, ����ģ��Ԥ����ƾ֤
        /// </summary>
        /// <param name="transferId"> ת��ID </param>
        /// <returns> viewToken </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual string GetViewToken(string transferId)
        {
            return viewTokenService.GrantViewToken(transferId);
        }

        /// <summary>
        ///     ������������
        /// </summary>
        /// <param name="transferId"> ת��ID </param>
        /// <param name="activeHours"> �ӵ�ǰ���𣬷������ӵ���Чʱ�䣬��λ��Сʱ; ���Ϊ�գ���ʾ�÷�������������Ч </param>
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
        ///     ������������,������Ч
        /// </summary>
        /// <param name="transferId"> ת��ID </param>
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
        ///     ɾ����������
        /// </summary>
        /// <param name="transferId"> ת��ID </param>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual void DeleteShareLink(string transferId)
        {
            shareLinkService.Delete(transferId);
        }

        /// <summary>
        ///     ��֤ǩ��, ����ת���ص�ʱʹ��
        /// </summary>
        /// <param name="signature"> ǩ���ַ� </param>
        /// <param name="transferId"> ת��ID </param>
        /// <param name="status"> ת��״̬(success || failed) </param>
        /// <returns> true: ��֤�ɹ�, false: У��ʧ�� </returns>
        /// <exception cref="BimfaceException">
        ///     <seealso cref="BimfaceException" />
        /// </exception>
        public virtual bool ValidateSignature(string signature, string transferId, string status, string nonce)
        {
            return signatureService.Validate(signature, transferId, status, nonce);
        }
    }
}