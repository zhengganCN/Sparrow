using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.Entities;
using System.Collections.Generic;

namespace Sparrow.Database.DAL.Test
{
    public class AddTest
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
        public void AddSingleData()
        {
            dal.Add(new EntitySchool
            {
                Name = "����ѧУ"
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
            dal.Add(data);
            Assert.Pass();
        }
    }
}