using NUnit.Framework;
using Sparrow.Extension.System.Test.Models;

namespace Sparrow.Extension.System.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MapTest()
        {
            var student = new Student
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
            };
            var dto = student.Map(e => new StudentDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
            });
            Assert.Pass();
        }

        [Test]
        public void Map1Test()
        {
            ///// <summary>
            ///// 
            ///// </summary>
            ///// <typeparam name="R">输出对象</typeparam>
            ///// <param name="source"></param>
            ///// <returns></returns>
            //public static R Map<R>(this object source) where R : class
            //{
            //    if (source == null) throw new ArgumentNullException("source");
            //    return;
            //}
            var student = new Student
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
            };
            //var dto = student.Map<StudentDto>();
            Assert.Pass();
        }
    }
}