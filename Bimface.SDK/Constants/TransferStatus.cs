namespace Bimface.SDK.Constants
{
    /// <summary>
    ///     枚举：转换状态
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public enum TransferStatus
    {
        /// <summary>
        ///     准备中
        /// </summary>
        PREPARE = 1,

        /// <summary>
        ///     转换中
        /// </summary>
        PROCESSING = 2,

        /// <summary>
        ///     转换成功
        /// </summary>
        SUCCESS = 3,

        /// <summary>
        ///     转换失败
        /// </summary>
        FAILED = 0,

        /// <summary>
        ///     未知状态
        /// </summary>
        UNRESOLVED = -1
    }
}