using NUnit.Framework;
using Sparrow.DataValidation.Test.Models;

namespace Sparrow.DataValidation.Test
{
    internal partial class SparrowValidationTest
    {
        [Test]
        public void ByteTest()
        {
            var valid = SparrowValidation.IsValid(new ByteModel(), out SparrowValidationInfo[] errors);
            Assert.IsFalse(valid);
            Assert.IsTrue(errors.Length > 0);
        }
    }
}
