using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    internal partial class DefaultStandardResultFaildTest
    {

        [Test]
        public void FailTest()
        {
            var dto = new Standard();
            dto.FailResult();
            Assert.IsTrue(dto.Code as string == "-1");
            Assert.IsTrue(dto.Message == "操作失败");
            dto.FailResult("失败1");
            Assert.IsTrue(dto.Code as string == "-1");
            Assert.IsTrue(dto.Message == "失败1");
            dto.FailResult("失败2", "2");
            Assert.IsTrue(dto.Code as string == "2");
            Assert.IsTrue(dto.Message == "失败2");
        }
        [Test]
        public void GenericFailTest()
        {
            var dto = new Standard();
            dto.FailResult();
            Assert.IsTrue(dto.Code as string == "-1");
            Assert.IsTrue(dto.Message == "操作失败");
            dto.FailResult("失败1");
            Assert.IsTrue(dto.Code as string == "-1");
            Assert.IsTrue(dto.Message == "失败1");
            dto.FailResult("失败2", "2");
            Assert.IsTrue(dto.Code as string == "2");
            Assert.IsTrue(dto.Message == "失败2");
        }
    }
}
