using Sparrow.Algorithm.Certificates;

namespace Sparrow.Algorithm.Test.Certificates
{
    internal class CertificateTest
    {
        [Test]
        [TestCase("511702800222130")]
        [TestCase("110101199001019298")]
        public void TrueTest(string number)
        {
            Assert.Multiple(() =>
            {
                Assert.That(new SparrowIdentityCard().GetIdentityCardInfo(number), Is.Not.EqualTo(null));
                Assert.That(SparrowCertificate.Verify(CertificateType.IdentityCard, number), Is.True);
            });
        }

        [Test]
        [TestCase("511702800252130")]
        [TestCase("110101199001019291")]
        public void FalseTest(string number)
        {
            Assert.Multiple(() =>
            {
                Assert.That(new SparrowIdentityCard().GetIdentityCardInfo(number), Is.EqualTo(null));
                Assert.That(SparrowCertificate.Verify(CertificateType.IdentityCard, number), Is.False);
            });
        }
    }
}
