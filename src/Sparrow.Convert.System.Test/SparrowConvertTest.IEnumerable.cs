namespace Sparrow.ConvertSystem.Test
{
    internal partial class SparrowConvertTest
    {

        [Test]
        public void SparrowConvertIEnumerableTest()
        {
            var array1 = new string[] { "a", "b", "c" };
            var array2 = new char[] { 'a', 'b', 'c' };
            var array3 = new List<string> { "a", "b", "c" };
            var array4 = new List<char> { 'a', 'b', 'c' };
            Assert.Multiple(() =>
            {
                Assert.That(SparrowConvert.ToString(array1, '-'), Is.EqualTo("a-b-c"));
                Assert.That(SparrowConvert.ToString(array2, '-'), Is.EqualTo("a-b-c"));
                Assert.That(SparrowConvert.ToString(array3, '-'), Is.EqualTo("a-b-c"));
                Assert.That(SparrowConvert.ToString(array4, '-'), Is.EqualTo("a-b-c"));
            });
        }
    }
}
