using Newtonsoft.Json;
using NUnit.Framework;
using Sparrow.StandardResult.Test.Models;
using Sparrow.StandardResult.Test.Utils;
using System.Collections.Generic;

namespace Sparrow.StandardResult.Test.StandardTest
{
    internal class FormatStandardTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FormatSuccessTest()
        {
            StandardOutputTypes.GetOverrideDefault();
            var data = "数据";
            var dto = new Standard();
            var dto_json = JsonConvert.SerializeObject(dto.SuccessResult(data));
            var json = JsonConvert.SerializeObject(new DefinedStandard
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

        [TestCase("other")]
        public void FormatKeySuccessTest(string key)
        {
            StandardOutputTypes.GetDefined(key);
            var data = "数据";
            var dto = new Standard(key);
            var dto_json = JsonConvert.SerializeObject(dto.SuccessResult(data));
            var json = JsonConvert.SerializeObject(new DefinedStandard
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
        public void OverrideDefaultFormatPaginationTest()
        {
            StandardOutputTypes.GetOverrideDefault();
            var standard = new Standard();
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var pagination = new StandardPagination<int>().GetPagination(list, 7, 1, 10);
            var obj = standard.SuccessResult(pagination, "成功");
            var defined = new
            {
                defined_success = standard.Success,
                defined_code = standard.Code,
                defined_data = new
                {
                    list,
                    page_size = 10,
                    total = 7,
                    page_count = 1,
                    page_num = 1
                },
                defined_message = standard.Message,
                defined_time = standard.Time,
                defined_traceid = standard.TraceId
            };
            Assert.IsTrue(CompareStandard.Compare(obj, defined));
        }
    }
}
