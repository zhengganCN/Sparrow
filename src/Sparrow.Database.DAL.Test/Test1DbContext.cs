using Microsoft.EntityFrameworkCore;
using Sparrow.Database.DAL.Test.Entities;

namespace Sparrow.Database.DAL.Test
{
    internal class Test1DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var con = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Test1DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(con);
        }

        internal DbSet<EntitySchool> EntitySchool { get; set; }
    }
}
