using NUnit.Framework;
using System.Collections.Generic;

namespace Sparrow.Extension.System.Test.ExtensionTest
{
    internal class ArrayCompareTest
    {
        [Test]
        [TestCase(null, null)]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 })]
        public void TrueTest(IEnumerable<int> array1, IEnumerable<int> array2)
        {
            Assert.That(array1.Compare(array2), Is.True);
        }
        [Test]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]
        [TestCase(null, new int[] { 1 })]
        [TestCase(new int[] { 1 }, null)]
        public void FalseTest(IEnumerable<int> array1, IEnumerable<int> array2)
        {
            Assert.That(array1.Compare(array2), Is.False);
        }
    }
}
