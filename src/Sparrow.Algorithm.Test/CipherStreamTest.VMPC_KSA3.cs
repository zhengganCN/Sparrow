using System.Text;

namespace Sparrow.Algorithm.Test
{
    public partial class CipherStreamTest
    {
        [Test]
        public void VMPC_KSA3()
        {
            var cipher = new SparrowStreamCipher();
            cipher.SetCipher(CipherStreamAlgorithm.VMPC_KSA3);
            cipher.SetIV(CipherConst.IV64Bytes);
            var encrypted = cipher.Encrypt(CipherConst.Original64Bytes, CipherConst.Key64Bytes);
            var decrypted = cipher.Decrypt(encrypted, CipherConst.Key64Bytes);
            var data = Encoding.UTF8.GetString(decrypted);
            Assert.That(CipherConst.Original64 == data, Is.True);
        }

    }
}
