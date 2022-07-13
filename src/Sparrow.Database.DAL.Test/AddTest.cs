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
    public class AddTest
    {
        private BaseDAL<DbContext> dal;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<DbContext, TestDbContext>();
            services.AddSingleton<BaseDAL<DbContext>>();
            services.AddSingleton<IMapper,Mapper>();
            var provider = services.BuildServiceProvider();
            dal = provider.GetService<BaseDAL<DbContext>>();
        }

        [Test]
        public void AddSingleData()
        {
            dal.Add(new EntitySchool
            {
                Name = "测试学校"
            });
            Assert.Pass();
        }

        [Test]
        public void AddMultipleData()
        {
            var data = new List<EntitySchool>
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
            dal.Add(data);
            Assert.Pass();
        }
    }
}