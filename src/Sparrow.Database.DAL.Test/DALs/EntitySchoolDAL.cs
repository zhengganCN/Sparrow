using Sparrow.Database.DAL.Test.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Database.DAL.Test.DALs
{
    public class EntitySchoolDAL : BaseDAL<Test1DbContext>
    {
        public EntitySchoolDAL(Test1DbContext context) : base(context)
        {
        }

        public List<EntitySchool> GetAllEntitySchools()
        {
            return Context.EntitySchool.AsQueryable().ToList();
        }
    }
}
