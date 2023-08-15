using Sparrow.Monitor.Enums;
using Sparrow.Monitor.Flow;

namespace Sparrow.Monitor.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            for (int i = 0; i < 100000; i++)
            {
                AccessFrequencyCachae.Access("get", "/weatherforecast", 1, AccessFrequencyUnit.Minite);
            }
            Assert.Pass();
        }
    }
}