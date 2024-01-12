//using Sparrow.Algorithm.Ciphers;
using System.Security.Cryptography;
using System.Text;

namespace Sparrow.Algorithm.Test
{
    public partial class CipherBlockTest
    {
        //    [Test]
        //    [TestCase(CipherMode.ECB, CipherPadding.NOPADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.RAW)]
        //    [TestCase(CipherMode.ECB, CipherPadding.ISO10126PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.ISO10126D2PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.ISO10126_2PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.ISO7816_4PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.ISO9797_1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.ISO9796_1)]
        //    [TestCase(CipherMode.ECB, CipherPadding.ISO9796_1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEP)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPPADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHMD5ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA1ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_1ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA224ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_224ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA256ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_256ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA256ANDMGF1WITHSHA256PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_256ANDMGF1WITHSHA_256PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA256ANDMGF1WITHSHA1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_256ANDMGF1WITHSHA_1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA384ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_384ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA512ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.OAEPWITHSHA_512ANDMGF1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.PKCS1)]
        //    [TestCase(CipherMode.ECB, CipherPadding.PKCS1PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.PKCS5)]
        //    [TestCase(CipherMode.ECB, CipherPadding.PKCS5PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.PKCS7)]
        //    [TestCase(CipherMode.ECB, CipherPadding.PKCS7PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.TBCPADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.WITHCTS)]
        //    [TestCase(CipherMode.ECB, CipherPadding.X923PADDING)]
        //    [TestCase(CipherMode.ECB, CipherPadding.ZEROBYTEPADDING)]
        //    public void AES(CipherMode mode, CipherPadding padding)
        //    {
        //        var cipher = new SparrowBlockCipher();
        //        cipher.SetCipher(CipherBlockAlgorithm.AES, mode, padding);
        //        var encrypted = cipher.Encrypt(CipherConst.Original128Bytes, CipherConst.Key128Bytes);
        //        var decrypted = cipher.Decrypt(encrypted, CipherConst.Key128Bytes);
        //        var data = Encoding.UTF8.GetString(decrypted);
        //        Assert.That(CipherConst.Original128 == data, Is.True);
        //    }
        /// <summary>
        /// 通过Key获取对称算法的初始化向量, 取Key的前16位
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static byte[] AESGetIVValueByKey(byte[] key)
        {
            if (key.Length < 16)
                throw new ArgumentException("无法从Key中获取偏移量!");
            return key.Take(16).ToArray();
        }

        // [TestCase(CipherMode.ECB, CipherPadding.PKCS5PADDING)]
        [Test]
        public void AES_ECB_PKCS5PADDING()//(CipherMode mode, CipherPadding padding)
        {
            //var cipher = new SparrowBlockCipher();
            try
            {
                Aes aesAlg = Aes.Create();
                aesAlg.Key = Encoding.UTF8.GetBytes("S3NFU2ZrQ0dmTUxhVTlQZQ==");
                aesAlg.Mode = System.Security.Cryptography.CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7; // 使用 PKCS7 填充模式

                ICryptoTransform decryptor = aesAlg.CreateDecryptor();

                using MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String("rNDTcZuGqrgvpqYHVxVeV2ual3gyE2tlwjVj5/SO4bsF9UwCyOpDBwBcx3O1y7yOsTOLV2mDMqdMPKq83H7FRaS+RRF8WtVgI2wWevt2Boq/RtEM5o4aujUbyznD1rxHKr8U1EQYouL9DRRC436D9aUHEKxB78RJ1PjrvafkrAo="));
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new StreamReader(csDecrypt);

                var s = srDecrypt.ReadToEnd();
                //var name = $"AES/ECB/PKCS5PADDING";
                //IBufferedCipher Cipher = CipherUtilities.GetCipher(name);
                //cipher.SetCipher(CipherBlockAlgorithm.AES, CipherMode.ECB, CipherPadding.PKCS5PADDING);
                //var text = "rNDTcZuGqrgvpqYHVxVeV2ual3gyE2tlwjVj5/SO4bsF9UwCyOpDBwBcx3O1y7yOsTOLV2mDMqdMPKq83H7FRaS+RRF8WtVgI2wWevt2Boq/RtEM5o4aujUbyznD1rxHKr8U1EQYouL9DRRC436D9aUHEKxB78RJ1PjrvafkrAo=";
                //byte[] ciphertext = Convert.FromBase64String(text);
                ////byte[] ciphertext = Encoding.UTF8.GetBytes(text);
                //byte[] key = Convert.FromBase64String("S3NFU2ZrQ0dmTUxhVTlQZQ==");//.Take(16).ToArray();
                //var decrypted = cipher.Decrypt(ciphertext, key);
                //var data = Encoding.ASCII.GetString(decrypted);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
