using NUnit.Framework;
using Sparrow.StandardResult.Test.Utils;
using System.Collections.Generic;

namespace Sparrow.StandardResult.Test.StandardTest
{
    internal class AdditionalStandardTest
    {

        [Test]
        public void AdditionalFieldTest()
        {
            StandardOutputTypes.GetOverrideDefault();
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var standard = new Standard();
            standard.AddAdditionalField("name", "zheng");
            standard.AddAdditionalField("age", 23);
            standard.SuccessResult(list, "成功");
            var additional = standard.StandardFormat();
            var defined = new
            {
                defined_success = standard.Success,
                defined_code = standard.Code,
                defined_data = list,
                defined_message = standard.Message,
                defined_time = standard.Time,
                defined_traceid = standard.TraceId,
                name = "zheng",
                age = 23
            };
            Assert.IsTrue(CompareStandard.Compare(additional, defined));
        }


        [Test]
        public void OverrideDefaultAdditionalFieldPaginationTest()
        {
            StandardOutputTypes.GetOverrideDefault();
            var standard = new Standard();
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var pagination = new StandardPagination<int>().GetPagination(list, 7, 1, 10);
            standard.AddAdditionalField("name", "zheng");
            standard.AddAdditionalField("age", 23);
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
                defined_traceid = standard.TraceId,
                name = "zheng",
                age = 23
            };
            Assert.IsTrue(CompareStandard.Compare(obj, defined));
        }
    }
}
