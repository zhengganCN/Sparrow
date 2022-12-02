using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Sparrow.Algorithm.Enums;

namespace Sparrow.Algorithm
{
    /// <summary>
    /// hash算法
    /// </summary>
    public static class SparrowHash
    {
        /// <summary>
        /// 获取哈希算法实例
        /// </summary>
        /// <param name="algorithm">算法</param>
        /// <returns></returns>
        public static IDigest GetDigest(HashAlgorithm algorithm)
        {
            IDigest hash = null;
            switch (algorithm)
            {
                case HashAlgorithm.Blake2b:
                    hash = new Blake2bDigest();
                    break;
                case HashAlgorithm.Blake2s:
                    hash = new Blake2sDigest();
                    break;
                case HashAlgorithm.Dstu7564_256:
                    hash = new Dstu7564Digest(256);
                    break;
                case HashAlgorithm.Dstu7564_384:
                    hash = new Dstu7564Digest(384);
                    break;
                case HashAlgorithm.Dstu7564_512:
                    hash = new Dstu7564Digest(512);
                    break;
                case HashAlgorithm.Gost3411:
                    hash = new Gost3411Digest();
                    break;
                case HashAlgorithm.Gost3411_2012_256:
                    hash = new Gost3411_2012_256Digest();
                    break;
                case HashAlgorithm.Gost3411_2012_512:
                    hash = new Gost3411_2012_512Digest();
                    break;
                case HashAlgorithm.Keccak:
                    hash = new KeccakDigest();
                    break;
                case HashAlgorithm.MD2:
                    hash = new MD2Digest();
                    break;
                case HashAlgorithm.MD4:
                    hash = new MD4Digest();
                    break;
                case HashAlgorithm.MD5:
                    hash = new MD5Digest();
                    break;
                case HashAlgorithm.Null:
                    hash = new NullDigest();
                    break;
                case HashAlgorithm.RipeMD128:
                    hash = new RipeMD128Digest();
                    break;
                case HashAlgorithm.RipeMD160:
                    hash = new RipeMD160Digest();
                    break;
                case HashAlgorithm.RipeMD256:
                    hash = new RipeMD256Digest();
                    break;
                case HashAlgorithm.RipeMD320:
                    hash = new RipeMD320Digest();
                    break;
                case HashAlgorithm.Sha1:
                    hash = new Sha1Digest();
                    break;
                case HashAlgorithm.Sha224:
                    hash = new Sha224Digest();
                    break;
                case HashAlgorithm.Sha256:
                    hash = new Sha256Digest();
                    break;
                case HashAlgorithm.Sha384:
                    hash = new Sha384Digest();
                    break;
                case HashAlgorithm.Sha3:
                    hash = new Sha3Digest();
                    break;
                case HashAlgorithm.Sha512:
                    hash = new Sha512Digest();
                    break;
                case HashAlgorithm.Shake:
                    hash = new ShakeDigest();
                    break;
                case HashAlgorithm.SM3:
                    hash = new SM3Digest();
                    break;
                case HashAlgorithm.Tiger:
                    hash = new TigerDigest();
                    break;
                case HashAlgorithm.Whirlpool:
                    hash = new WhirlpoolDigest();
                    break;
            }
            return hash;
        }

        /// <summary>
        /// 获取哈希算法实例
        /// </summary>
        /// <param name="algorithm">算法</param>
        /// <param name="N">函数名字符串，请注意，这是为NIST保留的。如果不需要，避免使用</param>
        /// <param name="S">自定义字符串-可供本地使用</param>
        /// <returns></returns>
        public static IDigest GetDigest(CShakeAlgorithm algorithm, byte[] N = null, byte[] S = null)
        {
            IDigest hash = null;
            switch (algorithm)
            {
                case CShakeAlgorithm.CShake128:
                    hash = new CShakeDigest(128, N, S);
                    break;
                case CShakeAlgorithm.CShake256:
                    hash = new CShakeDigest(256, N, S);
                    break;
            }
            return hash;
        }

        /// <summary>
        /// 获取哈希算法实例
        /// </summary>
        /// <param name="algorithm">算法</param>
        /// <param name="S">自定义字符串-可供本地使用</param>
        /// <returns></returns>
        public static IDigest GetDigest(TupleHashAlgorithm algorithm, byte[] S)
        {
            IDigest hash = null;
            switch (algorithm)
            {
                case TupleHashAlgorithm.TupleHash128:
                    hash = new TupleHash(128, S);
                    break;
                case TupleHashAlgorithm.TupleHash256:
                    hash = new TupleHash(256, S);
                    break;
            }
            return hash;
        }

        /// <summary>
        /// 获取哈希算法实例
        /// </summary>
        /// <param name="algorithm">算法</param>
        /// <param name="S">自定义字符串-可供本地使用</param>
        /// <param name="B">哈希的块大小（字节）</param>
        /// <returns></returns>
        public static IDigest GetDigest(ParallelHashAlgorithm algorithm, byte[] S, int B)
        {
            IDigest hash = null;
            switch (algorithm)
            {
                case ParallelHashAlgorithm.ParallelHash128:
                    hash = new ParallelHash(128, S, B);
                    break;
                case ParallelHashAlgorithm.ParallelHash256:
                    hash = new ParallelHash(256, S, B);
                    break;
            }
            return hash;
        }

        /// <summary>
        /// 获取哈希算法实例
        /// </summary>
        /// <param name="algorithm">算法</param>
        /// <param name="digestSizeBits">要生成的输出/摘要大小（以bit为单位），必须是整数字节</param>
        /// <returns></returns>
        public static IDigest GetDigest(SkeinAlgorithm algorithm, int digestSizeBits)
        {
            IDigest hash = null;
            switch (algorithm)
            {
                case SkeinAlgorithm.Skein256:
                    hash = new SkeinDigest(256, digestSizeBits);
                    break;
                case SkeinAlgorithm.Skein512:
                    hash = new SkeinDigest(512, digestSizeBits);
                    break;
                case SkeinAlgorithm.Skein1024:
                    hash = new SkeinDigest(1024, digestSizeBits);
                    break;
            }
            return hash;
        }

        /// <summary>
        /// 获取哈希算法实例
        /// </summary>
        /// <param name="algorithm">算法</param>
        /// <param name="bitLength">bit长度</param>
        /// <returns></returns>
        public static IDigest GetDigest(Sha512tAlgorithm algorithm, int bitLength)
        {
            IDigest hash = null;
            switch (algorithm)
            {
                case Sha512tAlgorithm.Sha512t:
                    hash = new Sha512tDigest(bitLength);
                    break;
            }
            return hash;
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="algorithm">哈希算法</param>
        /// <param name="original">原文字节</param>
        /// <returns>哈希字节</returns>
        public static byte[] ComputerHash(HashAlgorithm algorithm, byte[] original)
        {
            var digest = GetDigest(algorithm);
            return ComputerHash(digest, original);
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="algorithm">哈希算法</param>
        /// <param name="original">原文字节</param>
        /// <param name="bitLength">bit长度</param>
        /// <returns>哈希字节</returns>
        public static byte[] ComputerHash(Sha512tAlgorithm algorithm, byte[] original, int bitLength)
        {
            var digest = GetDigest(algorithm, bitLength);
            return ComputerHash(digest, original);
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="algorithm">哈希算法</param>
        /// <param name="original">原文字节</param>
        /// <param name="digestSizeBits">要生成的输出/摘要大小（以bit为单位），必须是整数字节</param>
        /// <returns>哈希字节</returns>
        public static byte[] ComputerHash(SkeinAlgorithm algorithm, byte[] original, int digestSizeBits)
        {
            var digest = GetDigest(algorithm, digestSizeBits);
            return ComputerHash(digest, original);
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="algorithm">哈希算法</param>
        /// <param name="original">原文字节</param>
        /// <param name="N">函数名字符串，请注意，这是为NIST保留的。如果不需要，避免使用</param>
        /// <param name="S">自定义字符串-可供本地使用</param>
        /// <returns>哈希字节</returns>
        public static byte[] ComputerHash(CShakeAlgorithm algorithm, byte[] original, byte[] N = null, byte[] S = null)
        {
            var digest = GetDigest(algorithm, N, S);
            return ComputerHash(digest, original);
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="algorithm">哈希算法</param>
        /// <param name="original">原文字节</param>
        /// <param name="S">自定义字符串-可供本地使用</param>
        /// <param name="B">哈希的块大小（字节）</param>
        /// <returns>哈希字节</returns>
        public static byte[] ComputerHash(ParallelHashAlgorithm algorithm, byte[] original, byte[] S, int B)
        {
            var digest = GetDigest(algorithm, S, B);
            return ComputerHash(digest, original);
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="digest">哈希算法</param>
        /// <param name="original">原文字节</param>
        /// <returns>哈希字节</returns>
        public static byte[] ComputerHash(IDigest digest, byte[] original)
        {
            var output = new byte[digest.GetDigestSize()];
            digest.BlockUpdate(original, 0, original.Length);
            digest.DoFinal(output, 0);
            return output;
        }
    }
}
