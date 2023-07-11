using Sparrow.Algorithm.Ciphers;
using System.Text;

namespace Sparrow.Algorithm.Test
{
    public partial class CipherBlockTest
    {
        [Test]
        [TestCase(CipherMode.ECB, CipherPadding.NOPADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.RAW)]
        [TestCase(CipherMode.ECB, CipherPadding.ISO10126PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.ISO10126D2PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.ISO10126_2PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.ISO7816_4PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.ISO9797_1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.ISO9796_1)]
        [TestCase(CipherMode.ECB, CipherPadding.ISO9796_1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEP)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPPADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHMD5ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA1ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_1ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA224ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_224ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA256ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_256ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA256ANDMGF1WITHSHA256PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_256ANDMGF1WITHSHA_256PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA256ANDMGF1WITHSHA1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_256ANDMGF1WITHSHA_1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA384ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_384ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA512ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_512ANDMGF1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.PKCS1)]
        [TestCase(CipherMode.ECB, CipherPadding.PKCS1PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.PKCS5)]
        [TestCase(CipherMode.ECB, CipherPadding.PKCS5PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.PKCS7)]
        [TestCase(CipherMode.ECB, CipherPadding.PKCS7PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.TBCPADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.WITHCTS)]
        [TestCase(CipherMode.ECB, CipherPadding.X923PADDING)]
        [TestCase(CipherMode.ECB, CipherPadding.ZEROBYTEPADDING)]
        public void XTEA(CipherMode mode, CipherPadding padding)
        {
            var cipher = new SparrowBlockCipher();
            cipher.SetCipher(CipherBlockAlgorithm.XTEA, mode, padding);
            var encrypted = cipher.Encrypt(CipherConst.Original128Bytes, CipherConst.Key128Bytes);
            var decrypted = cipher.Decrypt(encrypted, CipherConst.Key128Bytes);
            var data = Encoding.UTF8.GetString(decrypted);
            Assert.That(CipherConst.Original128 == data, Is.True);
        }

    }
}
