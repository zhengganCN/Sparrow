using Sparrow.Algorithm.Ciphers;
using System.Text;

namespace Sparrow.Algorithm.Test
{
    internal partial class AsymmetricBlockTest
    {
        [Test]
        public void RSA()
        {
            var cipher = new SparrowAsymmetricBlockCipher();
            cipher.SetCipher(CipherAsymmetricBlockAlgorithm.RSA);
            var encrypted = cipher.Encrypt(CipherConst.Original64Bytes, CipherConst.KeyPublicRSABytes);
            var decrypted = cipher.Decrypt(encrypted, CipherConst.KeyPrivateRSABytes);
            var data = Encoding.UTF8.GetString(decrypted);
            Assert.That(CipherConst.Original64 == data, Is.True);
        }
    }
}
