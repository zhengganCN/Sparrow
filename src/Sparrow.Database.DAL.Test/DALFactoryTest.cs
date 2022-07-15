using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.DALs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.DAL.Test
{
    internal class DALFactoryTest
    {
        private DALFactory<Test1DbContext> factory1;
        private IDALFactory<Test2DbContext> factory2;
        private DALFactory<Test3DbContext> factory3;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDAL<Test1DbContext>();
            services.AddDAL<Test2DbContext>();
            services.AddDAL<Test3DbContext>();
            var provider = services.BuildServiceProvider();
            factory1 = provider.GetService<DALFactory<Test1DbContext>>();
            factory2 = provider.GetService<IDALFactory<Test2DbContext>>();
            factory3 = provider.GetService<DALFactory<Test3DbContext>>();
        }

        [Test]
        public void DALInstantiationTest()
        {
            var schoolDAL = factory1.GetDAL<EntitySchoolDAL>();
            var schools = schoolDAL.GetAllEntitySchools();
            Assert.IsNotNull(schools);
        }

        [Test]
        public void IDALInstantiationTest()
        {
            var companyDAL = factory2.GetDAL<EntityCompanyDAL>();
            var schools = companyDAL.GetAllEntityCompanies();
            Assert.IsNotNull(schools);
        }

    }
}
