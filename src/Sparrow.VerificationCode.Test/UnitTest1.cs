namespace Sparrow.VerificationCode.Test
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
            var bytes = SparrowVerificationCode.GetImage(new CodeParamter
            {
                Code = "1265",
                Width = 150,
                Height = 30
            });
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code.png");
            File.WriteAllBytes(path, bytes);
            Assert.Pass();
        }
    }
}