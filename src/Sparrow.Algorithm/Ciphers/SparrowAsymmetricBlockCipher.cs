using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Sparrow.Algorithm.Enums;

namespace Sparrow.Algorithm.Ciphers
{
    /// <summary>
    /// 非对称块加密
    /// </summary>
    public class SparrowAsymmetricBlockCipher : SparrowCipher, ISparrowCipher
    {
        private CipherAsymmetricBlockAlgorithm Algorithm;
        private bool IsPrivateKey { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public SparrowAsymmetricBlockCipher() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="algorithm">加密算法</param>
        public SparrowAsymmetricBlockCipher(CipherAsymmetricBlockAlgorithm algorithm)
        {
            SetCipher(algorithm);
        }

        /// <summary>
        /// 设置加密参数
        /// </summary>
        /// <returns></returns>
        internal override ICipherParameters GetCipherParameters(byte[] key)
        {
            switch (Algorithm)
            {
                case CipherAsymmetricBlockAlgorithm.RSA:
                    if (IsPrivateKey)
                    {
                        return PrivateKeyFactory.CreateKey(key);
                    }
                    else
                    {
                        return PublicKeyFactory.CreateKey(key);
                    }
                    //case CipherAsymmetricBlockAlgorithm.ELGAMAL:
                    //    var parametersGenerator = new ElGamalParametersGenerator();
                    //    parametersGenerator.Init(512, 10, new SecureRandom());
                    //    var elGamalParameters = parametersGenerator.GenerateParameters();

                    //    var keyGeneration = new ElGamalKeyGenerationParameters(new SecureRandom(), elGamalParameters);
                    //    var gen = new ElGamalKeyPairGenerator();
                    //    gen.Init(keyGeneration);
                    //    var asymmetricCipherKeyPair = gen.GenerateKeyPair();

                    //    var pri = asymmetricCipherKeyPair.Private;
                    //    var el = (ElGamalPrivateKeyParameters)pri;
                    //    var p = el.X.ToByteArray();
                    //    var prk = Convert.ToBase64String(p);
                    //    var pp = (ElGamalPublicKeyParameters)asymmetricCipherKeyPair.Public;
                    //    var sds = pp.Y.ToByteArray();
                    //    var puk = Convert.ToBase64String(sds);

                    //    SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(asymmetricCipherKeyPair.Public);
                    //    var ssdfdfs = publicKeyInfo.PublicKeyData.GetEncoded("ascll");
                    //    var sdfdf = Encoding.ASCII.GetString(ssdfdfs);
                    //    PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(asymmetricCipherKeyPair.Private);
                    //    var sdfds1 = privateKeyInfo.PrivateKeyData.GetEncoded("ascll");
                    //    var sdfds1asd = Encoding.ASCII.GetString(sdfds1);
                    //    if (IsPrivateKey)
                    //    {
                    //        return PrivateKeyFactory.CreateKey(key);
                    //    }
                    //    else
                    //    {
                    //        return PublicKeyFactory.CreateKey(key);
                    //    }
            }
            return null;
        }

        /// <summary>
        /// 设置IBufferedCipher
        /// </summary>
        /// <param name="algorithm">加密算法</param>
        /// <returns></returns>
        public void SetCipher(CipherAsymmetricBlockAlgorithm algorithm)
        {
            Algorithm = algorithm;
            var name = $"{algorithm}";
            Cipher = CipherUtilities.GetCipher(name);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <returns></returns>
        public byte[] Decrypt(byte[] ciphertext, byte[] key)
        {
            IsPrivateKey = true;
            Cipher.Init(false, GetCipherParameters(key));
            return Cipher.DoFinal(ciphertext);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <returns></returns>
        public byte[] Encrypt(byte[] original, byte[] key)
        {
            IsPrivateKey = false;
            Cipher.Init(true, GetCipherParameters(key));
            return Cipher.DoFinal(original);
        }
    }
}
