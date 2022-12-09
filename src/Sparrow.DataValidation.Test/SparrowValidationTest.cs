using Newtonsoft.Json;
using NUnit.Framework;
using Sparrow.DataValidation.Test.Models;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test
{
    internal partial class SparrowValidationTest
    {
        [Test]
        [TestCase(null)]
        public void ValidationTest([Required(ErrorMessage = "必填")] int? age)
        {
            SparrowValidation.IsValid(new Student(), out _);
        }
    }
}
