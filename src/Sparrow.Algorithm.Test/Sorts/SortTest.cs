using Sparrow.Algorithm.Sorts;
using Sparrow.Extension.System;

namespace Sparrow.Algorithm.Test.Sorts
{
    internal class SortTest
    {
        [Test]
        [TestCase(new int[] { 12, 11, 13, 5, 6, 7 }, new int[] { 5, 6, 7, 11, 12, 13 })]
        public void Sort(int[] array, int[] res)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SparrowSort.Sort(array, SortAlgorithm.BubbleSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, SortAlgorithm.SelectionSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, SortAlgorithm.InsertionSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, SortAlgorithm.QuickSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, SortAlgorithm.MergeSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, SortAlgorithm.HeapSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, SortAlgorithm.ShellSort).Compare(res), Is.True);

                Assert.That(SparrowSort.Sort(array, InstabilitySortAlgorithm.HeapSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, InstabilitySortAlgorithm.SelectionSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, InstabilitySortAlgorithm.ShellSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, InstabilitySortAlgorithm.QuickSort).Compare(res), Is.True);

                Assert.That(SparrowSort.Sort(array, StabilitySortAlgorithm.MergeSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, StabilitySortAlgorithm.BubbleSort).Compare(res), Is.True);
                Assert.That(SparrowSort.Sort(array, StabilitySortAlgorithm.InsertionSort).Compare(res), Is.True);
            });
        }
    }
}
