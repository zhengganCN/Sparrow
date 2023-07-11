using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Sparrow.Algorithm.Enums;

namespace Sparrow.Algorithm.Ciphers
{
    /// <summary>
    /// 流加密算法
    /// </summary>
    public class SparrowStreamCipher : SparrowCipher, ISparrowCipher
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SparrowStreamCipher() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="algorithm">加密算法</param>
        public SparrowStreamCipher(CipherStreamAlgorithm algorithm)
        {
            SetCipher(algorithm);
        }

        /// <summary>
        /// 设置IBufferedCipher
        /// </summary>
        /// <param name="algorithm">加密算法</param>
        /// <returns></returns>
        public void SetCipher(CipherStreamAlgorithm algorithm)
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
            if (IV is null || IV.Length == 0)
            {
                return new KeyParameter(key);
            }
            else
            {
                return new ParametersWithIV(new KeyParameter(key), IV);
            }
        }
    }
}
