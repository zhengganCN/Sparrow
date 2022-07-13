using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.Entities;
using Sparrow.Database.DAL.Test.Models.Dto;
using System.Linq;

namespace Sparrow.Database.DAL.Test
{
    public class QueryTest
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
        public void QuerySingleData()
        {
            var schools = dal.GetQueryable<EntitySchool>();
            schools = schools.Where(e => e.Name.Contains("≤‚ ‘"));
            TypeAdapterConfig config = new TypeAdapterConfig();
            config.ForType<EntitySchool, SchoolDto>()
                .Map(d => d.Name, s => (s.Name + "hello"));
            var school = dal.First<EntitySchool, SchoolDto>(schools, config);
            school = dal.First<EntitySchool, SchoolDto>(schools);
            school = dal.First<EntitySchool, SchoolDto>(schools, null);
            Assert.Pass();
        }

        [Test]
        public void QueryMultipleData()
        {
            var schools = dal.GetQueryable<EntitySchool>();
            var condition = schools.Where(e => e.Name.Contains("≤‚ ‘"))
                .OrderByDescending(e => e.Name);
            TypeAdapterConfig config = new TypeAdapterConfig();
            config.NewConfig<EntitySchool, SchoolDto>()
                .Map(d => d.Name, s => (s.Name + "hello"));
            var school = dal.ToList<EntitySchool, SchoolDto>(condition, config);
            school = dal.ToList<EntitySchool, SchoolDto>(condition);
            school = dal.ToList<EntitySchool, SchoolDto>(condition, null);
            Assert.Pass();
        }
    }
}