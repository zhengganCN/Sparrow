using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    internal class FormatTest
    {
        private const string other = "other";
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult(option =>
            {
                option.FormatStandard = (dto) =>
                {
                    return new DefinedDto
                    {
                        defined_code = dto.Code as string,
                        defined_message = dto.Message,
                        defined_data = dto.Data,
                        defined_success = dto.Success,
                        defined_time = dto.Time,
                        defined_traceid = dto.TraceId,
                    };
                };
            });
            services.AddStandardResult(other, option =>
            {
                option.FormatStandard = (dto) =>
                {
                    return new OtherDto
                    {
                        other_code = dto.Code as string,
                        other_message = dto.Message,
                        other_data = dto.Data,
                        other_success = dto.Success,
                        other_time = dto.Time,
                        other_traceid = dto.TraceId,
                    };
                };
            });
        }

        [Test]
        public void FormatSuccessTest()
        {
            var data = "数据";
            var dto = new Standard();
            var dto_json = JsonConvert.SerializeObject(dto.SuccessResult(data));
            var json = JsonConvert.SerializeObject(new DefinedDto
            {
                defined_code = dto.Code as string,
                defined_message = dto.Message,
                defined_data = dto.Data,
                defined_success = dto.Success,
                defined_time = dto.Time,
                defined_traceid = dto.TraceId,
            });
            Assert.IsTrue(dto_json == json);
        }

        [Test]
        public void FormatKeySuccessTest()
        {
            var data = "数据";
            var dto = new Standard(other);
            var dto_json = JsonConvert.SerializeObject(dto.SuccessResult(data));
            var json = JsonConvert.SerializeObject(new OtherDto
            {
                other_code = dto.Code as string,
                other_message = dto.Message,
                other_data = dto.Data,
                other_success = dto.Success,
                other_time = dto.Time,
                other_traceid = dto.TraceId,
            });
            Assert.IsTrue(dto_json == json);
        }

    }
}
