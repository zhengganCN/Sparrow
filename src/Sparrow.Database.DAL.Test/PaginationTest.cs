using Mapster;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.Entities;
using Sparrow.Database.DAL.Test.Models.Dto;

namespace Sparrow.Database.DAL.Test
{
    internal class PaginationTest
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
        public void ToPagitationTest()
        {
            var schools = dal.GetQueryable<EntitySchool>();
            var pagination = dal.ToPagination(schools, 1, 10);
            var dest = dal.ToPagination<EntitySchool, SchoolDto>(schools, 1, 10);
            TypeAdapterConfig config = new TypeAdapterConfig();
            config.NewConfig<EntitySchool, SchoolDto>()
                .Map(d => d.Name, s => (s.Name + "hello"));
            dest = dal.ToPagination<EntitySchool, SchoolDto>(schools, 1, 10, null);
            dest = dal.ToPagination<EntitySchool, SchoolDto>(schools, 1, 10, config);
            Assert.IsNotNull(pagination);
            Assert.IsNotNull(dest);
        }
    }
}
