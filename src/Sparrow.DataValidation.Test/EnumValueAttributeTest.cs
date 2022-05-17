using NUnit.Framework;
using Sparrow.DataValidation.Attributes;

namespace Sparrow.DataValidation.Test
{
    public class EnumValueAttributeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VaildSuccessTest()
        {
            var enumValue = new EnumValueAttribute(typeof(DemoEnum));
            Assert.IsTrue(enumValue.IsValid(1));
            Assert.IsTrue(enumValue.IsValid("1"));
        }
        [Test]
        public void VaildFaildTest()
        {
            var enumValue = new EnumValueAttribute(typeof(DemoEnum));
            Assert.IsFalse(enumValue.IsValid(3));
            Assert.IsFalse(enumValue.IsValid("3"));
        }

        public enum DemoEnum
        {
            Hello = 1,
            World = 2
        }
    }
}