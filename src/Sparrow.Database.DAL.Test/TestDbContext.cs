using Microsoft.EntityFrameworkCore;
using Sparrow.Database.DAL.Test.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.DAL.Test
{
    internal class TestDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var con = @"Data Source=(localdb)\ProjectModels;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(con);
        }

        internal DbSet<EntitySchool> EntitySchool { get; set; }
    }
}
