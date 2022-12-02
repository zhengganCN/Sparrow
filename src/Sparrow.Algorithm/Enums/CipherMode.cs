namespace Sparrow.Algorithm.Enums
{
    /// <summary>
    /// 加密模式
    /// </summary>
    public enum CipherMode
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        ECB,
        NONE,
        CBC,
        CCM,
        CFB,
        CTR,
        CTS,
        EAX,
        GCM,
        GOFB,
        OCB,
        OFB,
        OPENPGPCFB,
        SIC
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    }
}
