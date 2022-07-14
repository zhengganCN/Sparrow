using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Database.DAL.Test
{
    public class UpdateTest
    {
        private BaseDAL<DbContext> dal;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<DbContext, TestDbContext>();
            services.AddSingleton<BaseDAL<DbContext>>();
            services.AddSingleton<IMapper, Mapper>();
            var provider = services.BuildServiceProvider();
            dal = provider.GetService<BaseDAL<DbContext>>();
        }

        [Test]
        public void UpdateSingleData()
        {
            var entity = new EntitySchool
            {
                Name = "测试学校"
            };
            dal.Add(entity);
            entity.CreateTime = DateTime.Now;
            var effect = dal.Update(entity);
            Assert.IsTrue(effect == 1);
        }

        [Test]
        public void UpdateMultipleData()
        {
            var entities = new List<EntitySchool>
            {
                new EntitySchool
                {
                    Name = "测试学校1"
                },
                new EntitySchool
                {
                    Name = "测试学校2"
                },
                new EntitySchool
                {
                    Name = "测试学校3"
                }
            };
            dal.Add(entities);
            foreach (var item in entities)
            {
                item.CreateTime = DateTime.Now;
            }
            var effect = dal.Update(entities);
            Assert.IsTrue(effect == 3);
        }


        [Test]
        public void ConditionUpdateData()
        {
            var updateable = dal.GetUpdateable<EntitySchool>()
                 .SetColumn(e => "SS1" == e.Name);
            var condition = dal.GetQueryable<EntitySchool>()
                .Where(e => e.Name.Contains("测试学校1"));
            updateable.SetUpdateCondition(condition);
            var effect = dal.Update(updateable);
            Assert.Pass();
        }

        [Test]
        public void ExceptionConditionUpdateData()
        {
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                var updateable = dal.GetUpdateable<EntitySchool>()
                    .SetColumn(null);
            });
            Assert.Throws(typeof(ArgumentException), () =>
            {
                var updateable = dal.GetUpdateable<EntitySchool>()
                    .SetColumn(e => true);
            });
            Assert.Throws(typeof(ArgumentException), () =>
            {
                var updateable = dal.GetUpdateable<EntitySchool>()
                    .SetColumn(null);
            });
            Assert.Pass();
        }
    }
}