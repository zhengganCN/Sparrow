using MapsterMapper;
using Sparrow.Database.DAL.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparrow.Database.DAL.Test
{
    public class EntitySchoolDAL : BaseDAL<Test1DbContext>
    {
        public EntitySchoolDAL(Test1DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public List<EntitySchool> GetAllEntitySchools()
        {
            return Context.EntitySchool.AsQueryable().ToList();
        }
    }
}
