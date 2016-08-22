using System;
using Bimface.SDK.Constants;

namespace Bimface.SDK.Bean.Response
{
    /// <summary>
    ///     �����ļ�ת���ķ��ز���
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class TransferBean
    {
        private string createTime; // ����ת����ʱ�䣬��ʽ��yyyy-MM-dd hh:mm:ss
        private string name; // �ļ����ƣ�������׺
        private string reason = string.Empty; // ת��ʧ�ܵ�ԭ������
        private string status; // ת��״̬
        private string[] thumbnail; // ����ͼ·��
        private string viewId; // ���ID

        public virtual string ViewId
        {
            get { return viewId; }
            set { viewId = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual string[] Thumbnail
        {
            get { return thumbnail; }
            set { thumbnail = value; }
        }

        public virtual string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public virtual string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        public virtual TransferStatus TransferStatus
        {
            get
            {
                TransferStatus s;
                if (Enum.TryParse(status, out s))
                    return s;
                return TransferStatus.UNRESOLVED;
            }
        }

        public override string ToString()
        {
            return
                string.Format(
                    "TransferBean [viewId={0}, name={1}, status={2}, thumbnail={3}, reason={4}, createTime={5}]", viewId,
                    name, status, thumbnail == null ? string.Empty : string.Join("-", thumbnail), reason, createTime);
        }
    }
}