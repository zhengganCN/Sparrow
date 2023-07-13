using NUnit.Framework;
using Sparrow.DataValidation.Test.Models;

namespace Sparrow.DataValidation.Test
{
    internal class CertificateNumAttributeTest
    {
        [Test]
        [TestCase("11010119900101821X")]
        public void TrueTest(string idcard)
        {
            Assert.That(SparrowValidation.IsValid(new IdCardNumber { IdCard = idcard }, out _), Is.True);
        }

        [Test]
        [TestCase("110101199001018211")]
        public void FalseTest(string idcard)
        {
            Assert.That(SparrowValidation.IsValid(new IdCardNumber { IdCard = idcard }, out _), Is.False);
        }
    }
}
