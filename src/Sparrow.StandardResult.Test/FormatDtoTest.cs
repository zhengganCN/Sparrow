using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    internal class FormatDtoTest
    {
        class DefinedDto
        {
#pragma warning disable IDE1006 // 命名样式
            public string defined_code { get; set; }
            public string defined_message { get; set; }
            public object Defined_data { get; set; }
            public bool defined_success { get; set; }
            public object defined_time { get; set; }
            public string defined_traceid { get; set; }
#pragma warning restore IDE1006 // 命名样式
        }
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult(option =>
            {
                option.FormatDto = (dto) =>
                {
                    return new DefinedDto
                    {
                        defined_code = dto.Code,
                        defined_message = dto.Message,
                        Defined_data = dto.Data,
                        defined_success = dto.Success,
                        defined_time = dto.Time,
                        defined_traceid = dto.TraceId,
                    };
                };
            });
        }

        [Test]
        public void FormatSerializeTest()
        {
            var dto = new StandardDto();
            dto.SuccessResult("数据");
            var format = dto.Format();
            var json = dto.Serialize();
            Assert.IsNotNull(format);
            Assert.IsNotEmpty(json);
        }

        [Test]
        public void GenericFormatSerializeTest()
        {
            var dto = new StandardDto<string>();
            dto.SuccessResult();
            var format = dto.Format();
            var json = dto.Serialize();
            Assert.IsNotNull(format);
            Assert.IsNotEmpty(json);
        }
    }
}
