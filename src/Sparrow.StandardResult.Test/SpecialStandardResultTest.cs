using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    public class SpecialStandardResultTest
    {
        private readonly string Key = "test";
        private readonly string SuccessMessage = "�ɹ�";
        private readonly string SuccessCode = "1";
        private readonly string FailMessage = "ʧ��";
        private readonly string FailCode = "2";
        private readonly string ExceptionMessage = "�쳣";
        private readonly string ExceptionCode = "3";

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddStandardResult(Key, option =>
            {
                option.SuccessMessage = "�ɹ�";
                option.SuccessCode = "1";
                option.FailMessage = "ʧ��";
                option.FailCode = "2";
                option.ExceptionMessage = "�쳣";
                option.ExceptionCode = "3";
            });
        }

        [Test]
        public void SuccessTest()
        {
            var dto = new Dto(Key);
            dto.SuccessResult();
            Assert.IsTrue(dto.Code == SuccessCode);
            Assert.IsTrue(dto.Message == SuccessMessage);
        }

        [Test]
        public void FailTest()
        {
            var dto = new Dto(Key);
            dto.FailResult();
            Assert.IsTrue(dto.Code == FailCode);
            Assert.IsTrue(dto.Message == FailMessage);
        }

        [Test]
        public void ExceptionTest()
        {
            var dto = new Dto(Key);
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code == ExceptionCode);
            Assert.IsTrue(dto.Message == ExceptionMessage);
        }

    }
}