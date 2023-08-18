using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    public class SpecialStandardResultTest
    {
        private readonly string Key = "test";
        private readonly string SuccessMessage = "成功";
        private readonly string SuccessCode = "1";
        private readonly string FailMessage = "失败";
        private readonly string FailCode = "2";
        private readonly string ExceptionMessage = "异常";
        private readonly string ExceptionCode = "3";

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddStandardResult(Key, option =>
            {
                option.SuccessMessage = "成功";
                option.SuccessCode = "1";
                option.FailMessage = "失败";
                option.FailCode = "2";
                option.ExceptionMessage = "异常";
                option.ExceptionCode = "3";
            });
        }

        [Test]
        public void SuccessTest()
        {
            var dto = new StandardDto(Key);
            dto.SuccessResult();
            Assert.IsTrue(dto.Code == SuccessCode);
            Assert.IsTrue(dto.Message == SuccessMessage);
        }

        [Test]
        public void FailTest()
        {
            var dto = new StandardDto(Key);
            dto.FailResult();
            Assert.IsTrue(dto.Code == FailCode);
            Assert.IsTrue(dto.Message == FailMessage);
        }

        [Test]
        public void ExceptionTest()
        {
            var dto = new StandardDto(Key);
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code == ExceptionCode);
            Assert.IsTrue(dto.Message == ExceptionMessage);
        }

    }
}