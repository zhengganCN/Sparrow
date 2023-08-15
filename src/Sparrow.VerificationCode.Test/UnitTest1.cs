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
            var param = new CodeParamter
            {
                Code = "1267",
                Width = 120,
                Height = 30
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var path = Path.Combine(dir, $"{param.Code}_{Guid.NewGuid()}.png");
            File.WriteAllBytes(path, bytes);
            Assert.Pass();
        }
    }
}