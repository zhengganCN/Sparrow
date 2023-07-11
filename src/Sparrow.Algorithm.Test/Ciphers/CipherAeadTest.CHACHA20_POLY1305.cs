using Sparrow.Algorithm.Ciphers;
using System.Text;

namespace Sparrow.Algorithm.Test
{
    public partial class CipherAeadTest
    {
        [Test]
        public void CHACHA20_POLY1305()
        {
            var cipher = new SparrowAeadCipher();
            cipher.SetCipher(CipherAeadAlgorithm.CHACHA20_POLY1305);
            cipher.SetIV(CipherConst.IV96Bytes);
            var encrypted = cipher.Encrypt(CipherConst.Original64Bytes, CipherConst.Key256Bytes);
            var decrypted = cipher.Decrypt(encrypted, CipherConst.Key256Bytes);
            var data = Encoding.UTF8.GetString(decrypted);
            Assert.That(CipherConst.Original64 == data, Is.True);
        }

    }
}
