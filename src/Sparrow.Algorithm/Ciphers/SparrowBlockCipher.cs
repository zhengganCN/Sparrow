using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Sparrow.Algorithm.Enums;

namespace Sparrow.Algorithm.Ciphers
{
    /// <summary>
    /// 块加密算法
    /// </summary>
    public class SparrowBlockCipher : SparrowCipher, ISparrowCipher
    {
        private CipherBlockAlgorithm Algorithm;
        /// <summary>
        /// Rounds
        /// </summary>
        public int Rounds { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public SparrowBlockCipher() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="algorithm">加密算法</param>
        /// <param name="mode">加密模式</param>
        /// <param name="padding">填充方式</param>
        public SparrowBlockCipher(CipherBlockAlgorithm algorithm, CipherMode mode, CipherPadding padding)
        {
            SetCipher(algorithm, mode, padding);
        }

        /// <summary>
        /// 设置IBufferedCipher
        /// </summary>
        /// <param name="algorithm">加密算法</param>
        /// <param name="mode">加密模式</param>
        /// <param name="padding">填充方式</param>
        /// <returns></returns>
        public void SetCipher(CipherBlockAlgorithm algorithm, CipherMode mode, CipherPadding padding)
        {
            Algorithm = algorithm;
            var name = $"{algorithm}/{mode}/{padding}";
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
            if (Algorithm == CipherBlockAlgorithm.RC5_64)
            {
                return new RC5Parameters(key, Rounds);
            }
            else
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
}
