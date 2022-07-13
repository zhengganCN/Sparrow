using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.DAL.Test
{
    internal class InitDB
    {
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<DbContext, TestDbContext>();
            services.AddSingleton<BaseDAL<DbContext>>();
            var provider = services.BuildServiceProvider();
            var context = provider.GetService<DbContext>();
            context.Database.EnsureCreated();
        }
    }
}
