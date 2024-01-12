using NUnit.Framework;
using Sparrow.Database.SqlSugar.Test.Entities;
using System;

namespace Sparrow.Database.SqlSugar.Test
{
    internal class DbSetTest
    {
        [Test]
        public void QueryTest()
        {
            using var context = new DemoDbContext();
            context.SugarClient.CodeFirst.InitTables(typeof(EntityDistricts));
            var districts = new EntityDistricts
            {
                CreateTime = DateTime.Now,
                Creator = "0",
                DistrictCode = "110",
                DistrictLevel = 1,
                DistrictName = "北京市",
                IsDeleted = false,
                ParentDistrictCode = "",
                DeleteTime = DateTime.Now,
                Deletor = "0",
                UpdateTime = DateTime.Now,
                Updator = "0"
            };
            context.Districts.Insert(districts);
            var exist = context.Districts.Queryable
                .Where(e => e.IsDeleted == false)
                .Where(e => e.DistrictCode == "110")
                .Any();
            Assert.IsTrue(exist);
        }
    }
}
