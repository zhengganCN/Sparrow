using Sparrow.Database.SqlSugar.Migrations;
using Sparrow.Database.SqlSugar.Test.Entities;

namespace Sparrow.Database.SqlSugar.Test.Migration
{
    internal class DemoSnakeMigration : SparrowSnakeDatabaseMigration
    {
        public override bool ExcuteBeforeDatabaseSynchronous()
        {
            return true;
        }

        public override bool ExcuteDatabaseSynchronous()
        {
            using var context = GetDbContext<DemoDbContext>();
            context.SugarClient.CodeFirst.InitTables(
                    typeof(EntityMigration));
            return true;
        }

        public override bool ExcuteAfterDatabaseSynchronous()
        {
            return true;
        }
    }
}
