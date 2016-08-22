namespace Bimface.SDK.Bean.Response
{
    /// <summary>
    ///     �ļ��ϴ��ķ��ز���
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class FileBean
    {
        private string createTime; // �ϴ�ʱ�䣬��ʽ��yyyy-MM-dd hh:mm:ss
        private long? fileId; // �ļ�ID
        private long? length; // �ļ���С������λ��byte��
        private string name; // �ļ����ƣ�������׺
        private string suffix; // �ļ���׺

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