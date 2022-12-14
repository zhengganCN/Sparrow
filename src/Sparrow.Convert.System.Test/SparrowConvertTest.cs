using Sparrow.ConvertSystem;

namespace Sparrow.Convert.System.Test
{
    internal partial class SparrowConvertTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SparrowConvertStringTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(SparrowConvert.Parse<bool>("true"), Is.EqualTo(true));
                Assert.That(SparrowConvert.Parse<bool?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<byte>("1"), Is.EqualTo(1));
                Assert.That(SparrowConvert.Parse<byte?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<sbyte>("1"), Is.EqualTo(1));
                Assert.That(SparrowConvert.Parse<sbyte?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<char>("1"), Is.EqualTo('1'));
                Assert.That(SparrowConvert.Parse<char?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<decimal>("12.33"), Is.EqualTo(12.33));
                Assert.That(SparrowConvert.Parse<decimal?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<double>("12.33"), Is.EqualTo(12.33));
                Assert.That(SparrowConvert.Parse<double?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<float>("12.33"), Is.EqualTo(12.33f));
                Assert.That(SparrowConvert.Parse<float?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<int>("16"), Is.EqualTo(16));
                Assert.That(SparrowConvert.Parse<int?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<uint>("16"), Is.EqualTo(16));
                Assert.That(SparrowConvert.Parse<uint?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<long>("16"), Is.EqualTo(16));
                Assert.That(SparrowConvert.Parse<long?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<short>("16"), Is.EqualTo(16));
                Assert.That(SparrowConvert.Parse<short?>(""), Is.EqualTo(null));
                Assert.That(SparrowConvert.Parse<ushort>("16"), Is.EqualTo(16));
                Assert.That(SparrowConvert.Parse<ushort?>(""), Is.EqualTo(null));
                var datetime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Assert.That(SparrowConvert.Parse<DateTime>(datetime.ToString("yyyy-MM-dd HH:mm:ss")), Is.EqualTo(datetime));
                Assert.That(SparrowConvert.Parse<DateTime?>(""), Is.EqualTo(null));
                var guid = Guid.NewGuid();
                Assert.That(SparrowConvert.Parse<Guid>(guid.ToString()), Is.EqualTo(guid));
                Assert.That(SparrowConvert.Parse<Guid?>(""), Is.EqualTo(null));
            });
        }
    }
}