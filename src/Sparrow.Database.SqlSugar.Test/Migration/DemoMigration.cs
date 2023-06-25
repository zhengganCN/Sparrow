using Sparrow.Database.Interface;
using Sparrow.Database.Migration;
using Sparrow.Database.SqlSugar.Test.Entities;
using System;
using System.IO;
using System.Text;

namespace Sparrow.Database.SqlSugar.Test.Migration
{
    internal class DemoMigration<D, V> : DefaultSparrowDatabaseMigration<D, V>
        where D : IDbContext, new()
        where V : class, ISparrowVersion, new()
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
        public override void ExcuteBeforeDatabaseSynchronous()
        {
            _stream.Write(Encoding.UTF8.GetBytes("ExcuteBeforeDatabaseSynchronous"));
        }
        public override void ExcuteDatabaseSynchronous()
        {
            Context.SugarClient.CodeFirst.InitTables(
                    typeof(EntityMigration));
            base.ExcuteDatabaseSynchronous();
        }
        public override void ExcuteAfterDatabaseSynchronous()
        {
            _stream.Write(Encoding.UTF8.GetBytes("ExcuteAfterDatabaseSynchronous"));
        }

    }
}
