using Sparrow.Database.SqlSugar.Extensions;
using Sparrow.Database.SqlSugar.Migrations;
using Sparrow.Database.SqlSugar.Test.Entities;
using Sparrow.Database.SqlSugar.Test.Views;
using System;
using System.Collections.Generic;

namespace Sparrow.Database.SqlSugar.Test.Migrations
{
    public class DemoDatabaseMigration : AbstractSparrowDatabaseMigration
    {

        public override bool ExcuteDatabaseSynchronous(MigrationOptions options)
        {
            using var context = new MigrationDbContext();
            var sheets = new List<Type>
            {
                typeof(EntityDistricts),
                typeof(EntityMigration)
            };
            context.SugarClient.CodeFirst.InitTables(sheets.ToArray());
            return true;
        }
        public override bool ExcuteViewSynchronous(MigrationOptions options)
        {
            using var context = new MigrationDbContext();
            context.InitView<ViewDistricts>(options);
            return true;
        }
    }
}
