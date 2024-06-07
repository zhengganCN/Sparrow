using Sparrow.Database.SqlSugar.Test.Entities;

namespace Sparrow.Database.SqlSugar.Test.Repositories
{
    internal class DistrictRepository : AbstractSparrowRepository
    {
        public int GetDistrictCount()
        {
            return Context.SugarClient.Queryable<EntityDistricts>()
                .Where(e => e.IsDeleted == false)
                .Count();
        }
    }
}
