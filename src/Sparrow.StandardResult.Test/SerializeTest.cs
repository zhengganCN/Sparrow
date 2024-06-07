using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Sparrow.StandardResult.Test
{
    internal class SerializeTest
    {
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
        }

        [Test]
        public void SerializeSuccessTest()
        {
            var data = "数据";
            var dto = new Standard();
            dto.SuccessResult(data);
            var json = JsonConvert.SerializeObject(new DefinedDto
            {
                defined_code = dto.Code as string,
                defined_message = dto.Message,
                defined_data = dto.Data,
                defined_success = dto.Success,
                defined_time = dto.Time,
                defined_traceid = dto.TraceId,
            });
            Assert.IsTrue(dto.Serialize() == json);
        }
    }
}
