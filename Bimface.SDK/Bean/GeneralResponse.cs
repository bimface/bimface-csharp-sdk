namespace Bimface.SDK.Bean
{
    /// <summary>
    ///     统一的返回类
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class GeneralResponse<T>
    {
        public const string CODE_SUCCESS = "success"; // 成功的业务编码
        public const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss"; // 统一的日期格式
        private string code = CODE_SUCCESS; // 返回的业务编码，默认成功
        private T data; // 执行成功后的返回结果
        private string message; // 失败的错误原因

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