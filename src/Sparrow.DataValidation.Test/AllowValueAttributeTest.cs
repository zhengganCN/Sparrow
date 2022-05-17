using NUnit.Framework;
using Sparrow.DataValidation.Attributes;

namespace Sparrow.DataValidation.Test
{
    public class AllowValueAttributeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VaildSuccessTest()
        {
            var allowValue = new AllowValueAttribute("1", 2);
            Assert.IsTrue(allowValue.IsValid("1"));
            Assert.IsTrue(allowValue.IsValid(2));
        }
        [Test]
        public void VaildFaildTest()
        {
            var allowValue = new AllowValueAttribute("1", 2);
            Assert.IsFalse(allowValue.IsValid(1));
            Assert.IsFalse(allowValue.IsValid(3));
            Assert.IsFalse(allowValue.IsValid("3"));
            Assert.IsFalse(allowValue.IsValid("2"));
        }
    }
}
