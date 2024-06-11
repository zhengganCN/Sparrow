using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Sparrow.StandardResult.Test.StandardTest
{
    public class TimeResultTest
    {
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
            services.AddDefaultStandardResult(option =>
            {
                option.SuccessMessage = "成功";
                option.SuccessCode = "1";
                option.FailMessage = "失败";
                option.FailCode = "2";
                option.ExceptionMessage = "异常";
                option.ExceptionCode = "3";
                option.Time = () =>
                {
                    return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                };
            });
        }

        [Test]
        public void SuccessTest()
        {
            var dto = new Standard();
            dto.SuccessResult();
            Assert.IsTrue(dto.Code as string == SuccessCode);
            Assert.IsTrue(dto.Message == SuccessMessage);
        }

        [Test]
        public void FailTest()
        {
            var dto = new Standard();
            dto.FailResult();
            Assert.IsTrue(dto.Code as string == FailCode);
            Assert.IsTrue(dto.Message == FailMessage);
        }

        [Test]
        public void ExceptionTest()
        {
            var dto = new Standard();
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code as string == ExceptionCode);
            Assert.IsTrue(dto.Message == ExceptionMessage);
        }

    }
}