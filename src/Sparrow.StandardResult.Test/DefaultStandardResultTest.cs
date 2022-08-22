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

        [Test]
        public void FailTest()
        {
            var dto = new StandardDto();
            dto.FailResult();
            Assert.IsTrue(dto.Code == "-1");
            Assert.IsTrue(dto.Message == "����ʧ��");
            dto.FailResult("ʧ��1");
            Assert.IsTrue(dto.Code == "-1");
            Assert.IsTrue(dto.Message == "ʧ��1");
            dto.FailResult("ʧ��2", "2");
            Assert.IsTrue(dto.Code == "2");
            Assert.IsTrue(dto.Message == "ʧ��2");
        }

        [Test]
        public void ExceptionTest()
        {
            var dto = new StandardDto();
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code == "-2");
            Assert.IsTrue(dto.Message == "δ֪����");
            dto.ExceptionResult("�쳣1");
            Assert.IsTrue(dto.Code == "-2");
            Assert.IsTrue(dto.Message == "�쳣1");
            dto.ExceptionResult("�쳣2", "001");
            Assert.IsTrue(dto.Code == "001");
            Assert.IsTrue(dto.Message == "�쳣2");
            dto.Success = false;
            Assert.IsTrue(dto.Success == false);
        }

        [Test]
        public void GenericSuccessTest()
        {
            var dto = new Dto<string>();
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

        [Test]
        public void GenericFailTest()
        {
            var dto = new Dto<string>();
            dto.FailResult();
            Assert.IsTrue(dto.Code == "-1");
            Assert.IsTrue(dto.Message == "����ʧ��");
            dto.FailResult("ʧ��1");
            Assert.IsTrue(dto.Code == "-1");
            Assert.IsTrue(dto.Message == "ʧ��1");
            dto.FailResult("ʧ��2", "2");
            Assert.IsTrue(dto.Code == "2");
            Assert.IsTrue(dto.Message == "ʧ��2");
        }

        [Test]
        public void GenericExceptionTest()
        {
            var dto = new Dto<string>();
            dto.ExceptionResult();
            Assert.IsTrue(dto.Code == "-2");
            Assert.IsTrue(dto.Message == "δ֪����");
            dto.ExceptionResult("�쳣1");
            Assert.IsTrue(dto.Code == "-2");
            Assert.IsTrue(dto.Message == "�쳣1");
            dto.ExceptionResult("�쳣2", "001");
            Assert.IsTrue(dto.Code == "001");
            Assert.IsTrue(dto.Message == "�쳣2");
            dto.Success = false;
            Assert.IsTrue(dto.Success == false);
        }

    }
}