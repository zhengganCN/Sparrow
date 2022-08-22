using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    public class DefaultStandardResultTest
    {
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult();
        }

        [Test]
        public void SuccessTest()
        {
            var dto = new StandardDto();
            dto.SuccessResult();
            Assert.IsTrue(dto.Code == "200");
            Assert.IsTrue(dto.Message == "操作成功");
            dto.SuccessResult(null, "成功1");
            Assert.IsTrue(dto.Code == "200");
            Assert.IsTrue(dto.Message == "成功1");
            dto.SuccessResult(null, "成功2", "1");
            Assert.IsTrue(dto.Code == "1");
            Assert.IsTrue(dto.Message == "成功2");
            dto.SuccessResult("数据");
            Assert.IsTrue(dto.Data.ToString() == "数据");
            Assert.IsTrue(dto.Success == true);
            Assert.IsNotEmpty(dto.TraceId);
            Assert.IsTrue(dto.Time != null);
        }

        [Test]
        public void FailTest()
        {
            var dto = new StandardDto();
            dto.FailResult();
            Assert.IsTrue(dto.Code == "-1");
            Assert.IsTrue(dto.Message == "操作失败");
            dto.FailResult("失败1");
            Assert.IsTrue(dto.Code == "-1");
            Assert.IsTrue(dto.Message == "失败1");
            dto.FailResult("失败2", "2");
            Assert.IsTrue(dto.Code == "2");
            Assert.IsTrue(dto.Message == "失败2");
        }

        [Test]
        public void ExceptionTest()
        {
            var dto = new StandardDto();
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code == "-2");
            Assert.IsTrue(dto.Message == "未知错误");
            dto.ExceptionResult("异常1");
            Assert.IsTrue(dto.Code == "-2");
            Assert.IsTrue(dto.Message == "异常1");
            dto.ExceptionResult("异常2", "001");
            Assert.IsTrue(dto.Code == "001");
            Assert.IsTrue(dto.Message == "异常2");
            dto.Success = false;
            Assert.IsTrue(dto.Success == false);
        }

        [Test]
        public void GenericSuccessTest()
        {
            var dto = new Dto<string>();
            dto.SuccessResult();
            Assert.IsTrue(dto.Code == "200");
            Assert.IsTrue(dto.Message == "操作成功");
            dto.SuccessResult(null, "成功1");
            Assert.IsTrue(dto.Code == "200");
            Assert.IsTrue(dto.Message == "成功1");
            dto.SuccessResult(null, "成功2", "1");
            Assert.IsTrue(dto.Code == "1");
            Assert.IsTrue(dto.Message == "成功2");
            dto.SuccessResult("数据");
            Assert.IsTrue(dto.Data.ToString() == "数据");
            Assert.IsTrue(dto.Success == true);
            Assert.IsNotEmpty(dto.TraceId);
            Assert.IsTrue(dto.Time != null);
        }

        [Test]
        public void GenericFailTest()
        {
            var dto = new Dto<string>();
            dto.FailResult();
            Assert.IsTrue(dto.Code == "-1");
            Assert.IsTrue(dto.Message == "操作失败");
            dto.FailResult("失败1");
            Assert.IsTrue(dto.Code == "-1");
            Assert.IsTrue(dto.Message == "失败1");
            dto.FailResult("失败2", "2");
            Assert.IsTrue(dto.Code == "2");
            Assert.IsTrue(dto.Message == "失败2");
        }

        [Test]
        public void GenericExceptionTest()
        {
            var dto = new Dto<string>();
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code == "-2");
            Assert.IsTrue(dto.Message == "未知错误");
            dto.ExceptionResult("异常1");
            Assert.IsTrue(dto.Code == "-2");
            Assert.IsTrue(dto.Message == "异常1");
            dto.ExceptionResult("异常2", "001");
            Assert.IsTrue(dto.Code == "001");
            Assert.IsTrue(dto.Message == "异常2");
            dto.Success = false;
            Assert.IsTrue(dto.Success == false);
        }

    }
}