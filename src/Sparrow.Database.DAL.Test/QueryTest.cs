using Mapster;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.DAL.Test.Entities;
using Sparrow.Database.DAL.Test.Models.Dto;
using System.Linq;

namespace Sparrow.Database.DAL.Test
{
    public class QueryTest
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
        public void QuerySingleData()
        {
            var schools = dal.Context.EntitySchool.AsQueryable();
            schools = schools.Where(e => e.Name.Contains("≤‚ ‘"));
            TypeAdapterConfig config = new TypeAdapterConfig();
            config.ForType<EntitySchool, SchoolDto>()
                .Map(d => d.Name, s => (s.Name + "hello"));
            var school = dal.Context.EntitySchool.AsQueryable()
                .FirstOrDefault<EntitySchool, SchoolDto>();
            school = dal.Context.EntitySchool.AsQueryable()
                .FirstOrDefault<EntitySchool, SchoolDto>(config);
            school = dal.Context.EntitySchool.AsQueryable()
                .FirstOrDefault<EntitySchool, SchoolDto>(null);
            Assert.Pass();
        }

        [Test]
        public void QueryMultipleData()
        {
            var schools = dal.Context.EntitySchool.AsQueryable();
            var condition = schools.Where(e => e.Name.Contains("≤‚ ‘"))
                .OrderByDescending(e => e.Name);
            TypeAdapterConfig config = new TypeAdapterConfig();
            config.NewConfig<EntitySchool, SchoolDto>()
                .Map(d => d.Name, s => (s.Name + "hello"));
            var school = dal.Context.EntitySchool.AsQueryable()
                .ToList<EntitySchool, SchoolDto>(config);
            school = dal.Context.EntitySchool.AsQueryable()
                .ToList<EntitySchool, SchoolDto>();
            school = dal.Context.EntitySchool.AsQueryable()
                .ToList<EntitySchool, SchoolDto>(null);
            Assert.Pass();
        }
    }
}