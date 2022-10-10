using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult.Test
{
    internal partial class DefaultStandardResultFaildTest
    {

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
        public void GenericFailTest()
        {
            var dto = new StandardDto<string>();
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
    }
}
