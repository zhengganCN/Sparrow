using NUnit.Framework;
using Sparrow.DataValidation.Test.Models;

namespace Sparrow.DataValidation.Test
{
    internal partial class SparrowValidationTest
    {
        [Test]
        public void ListTest()
        {
            var valid = SparrowValidation.IsValid(new ListModel(), out SparrowValidationInfo[] errors);
            Assert.IsFalse(valid);
            Assert.IsTrue(errors.Length > 0);
        }

        [Test]
        public void ListTest_2()
        {
            var valid = SparrowValidation.IsValid(new ListModel[]
            {
                new ListModel()
            }, out SparrowValidationInfo[] errors);
            Assert.IsFalse(valid);
            Assert.IsTrue(errors.Length > 0);
        }
    }
}
