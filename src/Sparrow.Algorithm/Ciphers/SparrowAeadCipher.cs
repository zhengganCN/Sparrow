using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Sparrow.Algorithm.Enums;

namespace Sparrow.Algorithm.Ciphers
{
    /// <summary>
    /// Aead加密
    /// </summary>
    public class SparrowAeadCipher : SparrowCipher, ISparrowCipher
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SparrowAeadCipher() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="algorithm">加密算法</param>
        public SparrowAeadCipher(CipherAeadAlgorithm algorithm)
        {
            SetCipher(algorithm);
        }

        /// <summary>
        /// 设置IBufferedCipher
        /// </summary>
        /// <param name="algorithm">加密算法</param>
        /// <returns></returns>
        public void SetCipher(CipherAeadAlgorithm algorithm)
        {
            var name = $"{algorithm}";
            Cipher = CipherUtilities.GetCipher(name);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <returns></returns>
        public byte[] Decrypt(byte[] ciphertext, byte[] key)
        {
            Cipher.Init(false, GetCipherParameters(key));
            return Cipher.DoFinal(ciphertext);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <returns></returns>
        public byte[] Encrypt(byte[] original, byte[] key)
        {
            Cipher.Init(true, GetCipherParameters(key));
            return Cipher.DoFinal(original);
        }

        internal override ICipherParameters GetCipherParameters(byte[] key)
        {
            return new ParametersWithIV(new KeyParameter(key), IV);
        }
    }
}
