namespace Bimface.SDK.Bean.Request
{
    /// <summary>
    ///     文件转换的请求参数
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class FileTransferRequest
    {
        private string callback; // 回调地址
        private long? fileId; // 文件id

        public FileTransferRequest()
        {
        }

        public FileTransferRequest(long? fileId)
        {
            this.fileId = fileId;
        }

        public FileTransferRequest(long? fileId, string callback)
        {
            this.fileId = fileId;
            this.callback = callback;
        }

        public virtual long? FileId
        {
            get { return fileId; }
            set { fileId = value; }
        }

        public virtual string Callback
        {
            get { return callback; }
            set { callback = value; }
        }

        public override string ToString()
        {
            return string.Format("FileTransferRequest [fileId={0}, callback={1}]", fileId, callback);
        }
    }
}