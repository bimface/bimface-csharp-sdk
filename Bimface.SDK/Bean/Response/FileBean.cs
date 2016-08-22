namespace Bimface.SDK.Bean.Response
{
    /// <summary>
    ///     文件上传的返回参数
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class FileBean
    {
        private string createTime; // 上传时间，格式：yyyy-MM-dd hh:mm:ss
        private long? fileId; // 文件ID
        private long? length; // 文件大小，（单位：byte）
        private string name; // 文件名称，包括后缀
        private string suffix; // 文件后缀

        public virtual long? FileId
        {
            get { return fileId; }
            set { fileId = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        public virtual long? Length
        {
            get { return length; }
            set { length = value; }
        }

        public virtual string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        public override string ToString()
        {
            return string.Format("FileBean [fileId={0}, name={1}, suffix={2}, length={3}, createTime={4}]", fileId, name,
                suffix, length, createTime);
        }
    }
}