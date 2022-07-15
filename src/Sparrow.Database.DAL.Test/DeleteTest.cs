using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Database.DAL.Test
{
    public class DeleteTest
    {
        private BaseDAL<Test1DbContext> dal;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDAL<Test1DbContext>();
            var provider = services.BuildServiceProvider();
            dal = provider.GetService<BaseDAL<Test1DbContext>>();
        }

        [Test]
        public void DeleteSingleData()
        {
            var entity = new EntitySchool
            {
                Name = "����ѧУ"
            };
            dal.Add(entity);
            var effect = dal.Remove(entity);
            Assert.IsTrue(effect == 1);
        }

        [Test]
        public void DeleteMultipleData()
        {
            var entities = new List<EntitySchool>
            {
                new EntitySchool
                {
                    Name = "����ѧУ1"
                },
                new EntitySchool
                {
                    Name = "����ѧУ2"
                },
                new EntitySchool
                {
                    Name = "����ѧУ3"
                }
            };
            dal.AddRange(entities);
            var effect = dal.RemoveRange(entities);
            Assert.IsTrue(effect == 3);
        }

        [Test]
        public void ConditionDeleteData()
        {
            var condition = dal.GetQueryable<EntitySchool>()
                .Where(e => e.Name == "����ѧУ2");
            var effect = dal.RemoveRange(condition);
            Assert.Pass();
        }
    }
}