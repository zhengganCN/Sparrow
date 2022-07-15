using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.DALs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.DAL.Test
{
    internal class InheritBaseDALTest
    {
        private EntitySchoolDAL schoolDAL;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDAL<Test1DbContext>();
            var provider = services.BuildServiceProvider();
            schoolDAL = provider.GetService<EntitySchoolDAL>();
        }

        [Test]
        public void InstantiationTest()
        {
            Assert.IsNotNull(schoolDAL);
        }
    }
}
