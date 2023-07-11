using Org.BouncyCastle.Crypto;

namespace Sparrow.Algorithm.Ciphers
{
    /// <summary>
    /// 加密算法
    /// </summary>
    public abstract class SparrowCipher
    {
        internal IBufferedCipher Cipher { get; set; }
        /// <summary>
        /// IV
        /// </summary>
        public byte[] IV { get; private set; }
        /// <summary>
        /// 设置IV
        /// </summary>
        /// <param name="iv">iv</param>
        public void SetIV(byte[] iv)
        {
            IV = iv;
        }
        /// <summary>
        /// 设置加密参数
        /// </summary>
        /// <returns></returns>
        internal abstract ICipherParameters GetCipherParameters(byte[] key);
    }
}
