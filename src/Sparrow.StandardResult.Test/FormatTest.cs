using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

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
                option.FormatStandardDto = (dto) =>
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
                option.FormatStandardDto = (dto) =>
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
            var dto = new StandardDto();
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
            var dto = new StandardDto(other);
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

        [Test]
        public void GenericFormatSuccessTest()
        {
            var data = "数据";
            var dto = new StandardDto<string>();
            dto.SuccessResult();
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
        public void GenericFormatKeySuccessTest()
        {
            var data = "数据";
            var dto = new StandardDto<string>(other);
            dto.SuccessResult();
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

        [Test]
        public void AdditionalFormatTest()
        {
            var list = new List<int>
            {
                1,2, 3, 4, 5, 6, 7
            };
            var additional = new Dictionary<string, object>
            {
                { "name", "zheng" },
                { "age", 23 }
            };
            var standard1 = new StandardDto();
            standard1.SuccessResult(list);
            var obj1 = standard1.Format(additional);
            var json1 = JsonConvert.SerializeObject(obj1);

            var standard2 = new StandardDto<List<int>>();
            standard2.SuccessResult(list);
            var obj2 = standard2.Format(additional);
            var json2 = JsonConvert.SerializeObject(obj2);
            Assert.Pass();
        }
    }
}
