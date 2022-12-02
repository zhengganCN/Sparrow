using System.Text;

namespace Sparrow.Algorithm.Test
{
    public partial class CipherStreamTest
    {
        [Test]
        public void CHACHA7539()
        {
            var cipher = new SparrowStreamCipher();
            cipher.SetCipher(CipherStreamAlgorithm.CHACHA7539);
            cipher.SetIV(CipherConst.IV96Bytes);
            var encrypted = cipher.Encrypt(CipherConst.Original256Bytes, CipherConst.Key256Bytes);
            var decrypted = cipher.Decrypt(encrypted, CipherConst.Key256Bytes);
            var data = Encoding.UTF8.GetString(decrypted);
            Assert.That(CipherConst.Original256 == data, Is.True);
        }

    }
}
