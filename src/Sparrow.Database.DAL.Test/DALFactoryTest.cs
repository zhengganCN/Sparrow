using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.DAL.Test
{
    internal class DALFactoryTest
    {
        private DALFactory<Test1DbContext> factory;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDAL<Test1DbContext>();
            var provider = services.BuildServiceProvider();
            factory = provider.GetService<DALFactory<Test1DbContext>>();
        }

        [Test]
        public void DALInstantiationTest()
        {
            var schoolDAL = factory.GetDAL<EntitySchoolDAL>();
            var schools = schoolDAL.GetAllEntitySchools();
            Assert.IsNotNull(schools);
        }
    }
}
