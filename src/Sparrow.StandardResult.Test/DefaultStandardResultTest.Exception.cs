using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult.Test
{
    internal partial class DefaultStandardResultTest
    {
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
        public void GenericExceptionTest()
        {
            var dto = new StandardDto<string>();
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
