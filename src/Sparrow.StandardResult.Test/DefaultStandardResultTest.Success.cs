using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    public partial class DefaultStandardResultSuccessTest
    {

        [Test]
        public void SuccessTest_1()
        {
            var dto = new StandardDto();
            dto.SuccessResult();
            Assert.IsTrue(dto.Code as string == StandardResultConsts.SuccessCode);
            Assert.IsTrue(dto.Message == StandardResultConsts.SuccessMessage);
        }

        [Test]
        public void SuccessTest_2()
        {
            var msg = "操作成功";
            var dto = new StandardDto();
            dto.SuccessResult(null, msg);
            Assert.IsTrue(dto.Code as string == StandardResultConsts.SuccessCode);
            Assert.IsTrue(dto.Message == msg);

        }

        [Test]
        public void SuccessTest_3()
        {
            var code = "1";
            var msg = "操作成功";
            var dto = new StandardDto();
            dto.SuccessResult(null, msg, code);
            Assert.IsTrue(dto.Code as string == code);
            Assert.IsTrue(dto.Message == msg);
        }

        [Test]
        public void SuccessTest_4()
        {
            var data = "操作成功";
            var dto = new StandardDto();
            dto.SuccessResult(data);
            Assert.IsTrue(dto.Data.ToString() == data);
            Assert.IsTrue(dto.Success == true);
            Assert.IsNotEmpty(dto.TraceId);
            Assert.IsTrue(dto.Time != null);
        }


        [Test]
        public void GenericSuccessTest()
        {
            var dto = new StandardDto<string>();
            dto.SuccessResult();
            Assert.IsTrue(dto.Code as string == "200");
            Assert.IsTrue(dto.Message == "操作成功");
            dto.SuccessResult(null, "成功");
            Assert.IsTrue(dto.Code as string == "200");
            Assert.IsTrue(dto.Message == "成功");
            dto.SuccessResult(null, "通过", "1");
            Assert.IsTrue(dto.Code as string == "1");
            Assert.IsTrue(dto.Message == "通过");
            dto.SuccessResult("成功");
            Assert.IsTrue(dto.Data.ToString() == "成功");
            Assert.IsTrue(dto.Success == true);
            Assert.IsNotEmpty(dto.TraceId);
            Assert.IsTrue(dto.Time != null);
        }





    }
}