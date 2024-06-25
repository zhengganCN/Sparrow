using NUnit.Framework;
using Sparrow.StandardResult.Test.Models;
using Sparrow.StandardResult.Test.Utils;
using System.Collections.Generic;

namespace Sparrow.StandardResult.Test.PaginationTest
{
    internal class FormatPaginationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OverrideDefaultFormatTest()
        {
            StandardPaginationOutputTypes.GetOverrideDefault();
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var defined = new DefinedPagination
            {
                list = list,
                page_size = 10,
                total = 7,
                page_count = 1,
                page_num = 1
            };
            var pagination = new StandardPagination<int>();
            var obj = pagination.GetPagination(list, 7, 1, 10).StandardFormat();
            Assert.IsTrue(CompareStandard.Compare(obj, defined));
        }

        [Test]
        public void FormatTest()
        {
            StandardPaginationOutputTypes.GetOverrideDefault();
            var list = new List<StudentView>
            {
                new StudentView
                {
                    Name = "Tom",
                    Age = 22
                }
            };
            var pagination = new StandardPagination<StudentView>().GetPagination(list, 1).StandardFormat();
            var standard = new Standard();
            standard.SuccessResult(pagination);            
            var serialize = standard.Serialize();
            Assert.IsTrue(serialize.Contains("\"name\":\"Tom\""));            
        }

    }
}
