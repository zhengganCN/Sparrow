using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace Sparrow.StandardResult.Test
{
    internal class PaginationTest
    {
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult(option =>
            {
                option.FormatStandardPagination = (pagination) =>
                {
                    return new
                    {
                        list = pagination.List,
                        page_num = pagination.PageIndex,
                        page_size = pagination.PageSize,
                        total = pagination.Count,
                        page_count = pagination.PageCount,
                    };
                };
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
        public void FormatTest()
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
            var pagination1 = new StandardPagination<int>();
            var obj1 = pagination1.GetPagination(list, 7, 1, 10);
            var json1 = JsonConvert.SerializeObject(obj1);

            var pagination2 = new StandardPagination<int>();
            var obj2 = pagination2.GetPagination(list, 7, 1, 10);
            var json2 = JsonConvert.SerializeObject(obj2);
            Assert.Pass();
        }

    }
}
