﻿using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    internal partial class DefaultStandardResultTest
    {
        [Test]
        public void ExceptionTest()
        {
            var dto = new Standard();
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code as string == "-2");
            Assert.IsTrue(dto.Message == "未知错误");
            dto.ExceptionResult("异常1");
            Assert.IsTrue(dto.Code as string == "-2");
            Assert.IsTrue(dto.Message == "异常1");
            dto.ExceptionResult("异常2", "001");
            Assert.IsTrue(dto.Code as string == "001");
            Assert.IsTrue(dto.Message == "异常2");
            dto.Success = false;
            Assert.IsTrue(dto.Success == false);
        }
        [Test]
        public void GenericExceptionTest()
        {
            var dto = new Standard();
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code as string == "-2");
            Assert.IsTrue(dto.Message == "未知错误");
            dto.ExceptionResult("异常1");
            Assert.IsTrue(dto.Code as string == "-2");
            Assert.IsTrue(dto.Message == "异常1");
            dto.ExceptionResult("异常2", "001");
            Assert.IsTrue(dto.Code as string == "001");
            Assert.IsTrue(dto.Message == "异常2");
            dto.Success = false;
            Assert.IsTrue(dto.Success == false);
        }
    }
}
