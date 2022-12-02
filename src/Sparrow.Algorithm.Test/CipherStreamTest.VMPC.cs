﻿using System.Text;

namespace Sparrow.Algorithm.Test
{
    public partial class CipherStreamTest
    {
        [Test]
        public void VMPC()
        {
            var cipher = new SparrowStreamCipher();
            cipher.SetCipher(CipherStreamAlgorithm.VMPC);
            cipher.SetIV(CipherConst.IV64Bytes);
            var encrypted = cipher.Encrypt(CipherConst.Original128Bytes, CipherConst.Key128Bytes);
            var decrypted = cipher.Decrypt(encrypted, CipherConst.Key128Bytes);
            var data = Encoding.UTF8.GetString(decrypted);
            Assert.That(CipherConst.Original128 == data, Is.True);
        }

    }
}
