namespace Sparrow.Algorithm.Enums
{
    /// <summary>
    /// 流加密算法
    /// </summary>
    public enum CipherStreamAlgorithm
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        ARC4,
        CHACHA,
        CHACHA7539,
        HC128,
        HC256,
        PBEWITHSHAAND128BITRC4,
        PBEWITHSHAAND40BITRC4,
        SALSA20,
        VMPC,
        VMPC_KSA3,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    }
}
