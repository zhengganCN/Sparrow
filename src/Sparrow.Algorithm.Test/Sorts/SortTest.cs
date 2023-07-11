using Sparrow.Algorithm.Sorts;

namespace Sparrow.Algorithm.Test.Sorts
{
    internal class SortTest
    {
        [Test]
        [TestCase(new int[] { 12, 11, 13, 5, 6, 7 }, new int[] { 5, 6, 7, 11, 12, 13 })]
        public void Sort(int[] array, int[] res)
        {
            var quick = SparrowSort.Sort(array, SortAlgorithm.QuickSort);

            if (quick.Equals(res))
            {

            }
            var shell = SparrowSort.Sort(array, SortAlgorithm.ShellSort);

        }



    }
}
