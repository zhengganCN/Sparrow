using MapsterMapper;
using Sparrow.Database.DAL.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparrow.Database.DAL.Test.DALs
{
    public class EntityCompanyDAL : BaseDAL<Test2DbContext>
    {
        public EntityCompanyDAL(Test2DbContext context) : base(context)
        {
        }

        public List<EntityCompany> GetAllEntityCompanies()
        {
            return Context.EntityCompany.AsQueryable().ToList();
        }
    }
}
