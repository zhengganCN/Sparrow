using NUnit.Framework;
using Sparrow.DataValidation.Test.Models;

namespace Sparrow.DataValidation.Test
{
    internal partial class SparrowValidationTest
    {
        [Test]
        public void LongTest()
        {
            var valid = SparrowValidation.IsValid(new LongModel(), out SparrowValidationInfo[] errors);
            Assert.IsFalse(valid);
            Assert.IsTrue(errors.Length > 0);
        }
    }
}
