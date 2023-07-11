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
            Assert.IsTrue(dto.Code == StandardResultConsts.SuccessCode);
            Assert.IsTrue(dto.Message == StandardResultConsts.SuccessMessage);
        }

        [Test]
        public void SuccessTest_2()
        {
            var msg = "�ɹ�";
            var dto = new StandardDto();
            dto.SuccessResult(null, msg);
            Assert.IsTrue(dto.Code == StandardResultConsts.SuccessCode);
            Assert.IsTrue(dto.Message == msg);

        }

        [Test]
        public void SuccessTest_3()
        {
            var code = "1";
            var msg = "�ɹ�";
            var dto = new StandardDto();
            dto.SuccessResult(null, msg, code);
            Assert.IsTrue(dto.Code == code);
            Assert.IsTrue(dto.Message == msg);
        }

        [Test]
        public void SuccessTest_4()
        {
            var data = "�ɹ�";
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
            Assert.IsTrue(dto.Code == "200");
            Assert.IsTrue(dto.Message == "�����ɹ�");
            dto.SuccessResult(null, "�ɹ�1");
            Assert.IsTrue(dto.Code == "200");
            Assert.IsTrue(dto.Message == "�ɹ�1");
            dto.SuccessResult(null, "�ɹ�2", "1");
            Assert.IsTrue(dto.Code == "1");
            Assert.IsTrue(dto.Message == "�ɹ�2");
            dto.SuccessResult("����");
            Assert.IsTrue(dto.Data.ToString() == "����");
            Assert.IsTrue(dto.Success == true);
            Assert.IsNotEmpty(dto.TraceId);
            Assert.IsTrue(dto.Time != null);
        }





    }
}