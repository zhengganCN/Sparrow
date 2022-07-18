using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.Entities;
using System.Collections.Generic;

namespace Sparrow.Database.DAL.Test
{
    public class RemoveTest
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
            var effect = dal.AsRemoveable<EntitySchool>()
                .Where(e => e.Name == "����ѧУ2")
                .ExecuteCommand();
            Assert.Pass();
        }
    }
}