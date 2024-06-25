using Sparrow.Database.SqlSugar.Migrations;
using Sparrow.Database.SqlSugar.Test.Entities;

namespace Sparrow.Database.SqlSugar.Test.Views
{
    internal class ViewDistricts : AbstractSparrowView
    {
        public override string DefineView(DbContext context, out string name, out SparrowVersion version)
        {
            name = nameof(ViewDistricts);
            version = new SparrowVersion
            {
                Major = 1,
                Minor = 0,
                Revision = 0,
                Temporary = 1
            };
            return context.SugarClient.Queryable<EntityDistricts>()
                .Where(e => e.IsDeleted == false)
                .ToSqlString();
        }
    }
}
