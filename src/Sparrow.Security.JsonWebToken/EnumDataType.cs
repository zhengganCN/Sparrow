namespace Sparrow.Security.JsonWebToken
{
    /// <summary>
    /// 枚举转换数据类型
    /// </summary>
    internal enum EnumDataType
    {
        /// <summary>
        /// jwt框架header解码
        /// </summary>
        FrameHeaderDecoder = 1,
        /// <summary>
        /// jwt框架payload解码
        /// </summary>
        FramePayloadDecoder = 2,
        /// <summary>
        /// jwt自定义header解码
        /// </summary>
        SelfHeaderDecoder = 3,
        /// <summary>
        /// jwt自定义header解码
        /// </summary>
        SelfPayloadDecoder = 4
    }
}
