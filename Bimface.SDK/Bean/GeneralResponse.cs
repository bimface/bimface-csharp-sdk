namespace Bimface.SDK.Bean
{
    /// <summary>
    ///     ͳһ�ķ�����
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class GeneralResponse<T>
    {
        public const string CODE_SUCCESS = "success"; // �ɹ���ҵ�����
        public const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss"; // ͳһ�����ڸ�ʽ
        private string code = CODE_SUCCESS; // ���ص�ҵ����룬Ĭ�ϳɹ�
        private T data; // ִ�гɹ���ķ��ؽ��
        private string message; // ʧ�ܵĴ���ԭ��

        public GeneralResponse()
        {
        }

        public GeneralResponse(T data)
        {
            this.data = data;
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual string Message
        {
            get { return message; }
            set { message = value; }
        }

        public virtual T Data
        {
            get { return data; }
            set { data = value; }
        }

        public override string ToString()
        {
            return string.Format("GeneralResponse [code={0}, message={1}, data={2}]", code, message, data);
        }
    }
}