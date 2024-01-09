using Sparrow.Database.Interface;
using Sparrow.Database.Migration;
using Sparrow.Database.SqlSugar.Test.Entities;
using System;
using System.IO;
using System.Text;

namespace Sparrow.Database.SqlSugar.Test.Migration
{
    internal class DemoMigration<D> : DefaultSparrowDatabaseMigration<D>
        where D : IDbContext, new()
    {
        private readonly FileStream _stream;

        public DemoMigration()
        {
            _stream = File.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "migration.txt"), FileMode.OpenOrCreate);
        }

        ~DemoMigration()
        {
            _stream.Close();
        }

        public override void ExcuteBeforeDatabaseSynchronous<V>(V version)
        {
            _stream.Write(Encoding.UTF8.GetBytes("ExcuteBeforeDatabaseSynchronous"));
        }

        public override void ExcuteDatabaseSynchronous<V>(V version)
        {
            Context.SugarClient.CodeFirst.InitTables(
                    typeof(EntityMigration));
            base.ExcuteDatabaseSynchronous(version);
        }

        public override void ExcuteAfterDatabaseSynchronous<V>(V version)
        {
            _stream.Write(Encoding.UTF8.GetBytes("ExcuteAfterDatabaseSynchronous"));
        }
    }
}
