namespace Bimface.SDK.Constants
{
    /// <summary>
    ///     ����
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class BimfaceConstants
    {
        // API��������ַ
        public const string API_HOST = "https://api.bimface.com";
        // �ļ��ϴ�API��������ַ
        public const string FILE_HOST = "https://file.bimface.com";
        public const string STREAM_MIME = "application/octet-stream";
        public const string JSON_MIME = "application/json";
        public const string FORM_MIME = "application/x-www-form-urlencoded";
        // �ϵ��ϴ�ʱ�ķֿ��С(Ĭ�ϵķֿ��С, ������ı�)
        public const int BLOCK_SIZE = 4*1024*1024;
        // ������������
        public const int DEFAULT_MAX_IDLE_CONNECTIONS = 32;
        // ���ֻ����ʱ��
        public const long DEFAULT_KEEP_ALIVE_DURATION_NS = 5*60*1000;
        // ���������
        public const int DEFAULT_MAX_REQUESTS = 64;
        // ÿ̨��������������
        public const int DEFAULT_MAX_REQUESTS_PER_HOST = 5;
        // ���ӳ�ʱʱ�� ��λ��(Ĭ��10000 ms)
        public const int DEFAULT_CONNECT_TIMEOUT = 100000;
        // д��ʱʱ�� ��λ��(Ĭ�� 0 ms , ����ʱ)
        public const int DEFAULT_WRITE_TIMEOUT = 0;
        // ��д��ʱʱ�� ��λ��(Ĭ�� 0 ms , ����ʱ)
        public const int DEFAULT_READ_WRITE_TIMEOUT = 100000;
        // �ظ���ʱʱ�� ��λ��(Ĭ��30000 ms)
        public const int DEFAULT_RESPONSE_TIMEOUT = 30000;
        // Ĭ���ַ�������
        public static readonly int UTF_8 = 65001;
        public static readonly string MEDIA_TYPE_JSON = "application/json; charset=utf-8";
        // ����ļ���С���ڴ�ֵ��ʹ�öϵ��ϴ�, ����ʹ��Form�ϴ�
        public static int PUT_THRESHOLD = BLOCK_SIZE;
    }
}