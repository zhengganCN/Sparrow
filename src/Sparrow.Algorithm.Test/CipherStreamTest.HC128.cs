using System.Text;

namespace Sparrow.Algorithm.Test
{
    public partial class CipherStreamTest
    {
        [Test]
        public void HC128()
        {
            var cipher = new SparrowStreamCipher();
            cipher.SetCipher(CipherStreamAlgorithm.HC128);
            var encrypted = cipher.Encrypt(CipherConst.Original128Bytes, CipherConst.Key128Bytes);
            var decrypted = cipher.Decrypt(encrypted, CipherConst.Key128Bytes);
            var data = Encoding.UTF8.GetString(decrypted);
            Assert.That(CipherConst.Original128 == data, Is.True);
        }

    }
}
