using NUnit.Framework;
using Sparrow.StandardResult.Test.Utils;
using System.Collections.Generic;

namespace Sparrow.StandardResult.Test.PaginationTest
{
    internal class AdditionalPaginationTest
    {

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void AdditionalFieldTest()
        {
            StandardPaginationOutputTypes.GetOverrideDefault();
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var defined = new
            {
                list,
                page_size = 10,
                total = 7,
                page_count = 1,
                page_num = 1,
                name = "zheng",
                age = 23
            };
            var pagination = new StandardPagination<int>();
            var obj = pagination.GetPagination(list, 7, 1, 10);
            obj.AddAdditionalField("name", "zheng");
            obj.AddAdditionalField("age", 23);
            var format = obj.StandardFormat();
            Assert.IsTrue(CompareStandard.Compare(format, defined));
        }
    }
}
