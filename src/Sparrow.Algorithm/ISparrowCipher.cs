namespace Sparrow.Algorithm
{
    /// <summary>
    /// 加密接口
    /// </summary>
    public interface ISparrowCipher
    {
        /// <summary>
        /// 解密
        /// </summary>
        /// <returns></returns>
        byte[] Decrypt(byte[] ciphertext, byte[] key);

        /// <summary>
        /// 加密
        /// </summary>
        /// <returns></returns>
        byte[] Encrypt(byte[] original, byte[] key);

    }
}
