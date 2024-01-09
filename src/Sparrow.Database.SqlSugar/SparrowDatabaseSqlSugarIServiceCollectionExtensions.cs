using Sparrow.Database.Interface;
using Sparrow.Database.Migration;
using Sparrow.Database.SqlSugar;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// <see cref="IServiceCollection"/>扩展
    /// </summary>
    public static class SparrowDatabaseSqlSugarIServiceCollectionExtensions
    {
        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="version">版本</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowDatabaseMigration<M, V>(this IServiceCollection services, V version)
            where M : ISparrowDatabaseMigration, new() 
            where V : class, ISparrowVersion, new()
        {
            var migration = new M();
            if (migration.ExistVersionTable<V>())
            {
                var current_version = migration.GetCurrentVersion<V>(version.Name);
                if (current_version == null || version.Compare(current_version) > 0)
                {
                    ExcuteMigration(migration, version);
                }
            }
            else
            {
                ExcuteMigration(migration, version);
            }
            return services;
        }

        private static void ExcuteMigration<V>(ISparrowDatabaseMigration migration, V sparrow) where V : class, ISparrowVersion, new()
        {
            migration.ExcuteBeforeDatabaseSynchronous(sparrow);
            migration.ExcuteDatabaseSynchronous(sparrow);
            migration.ExcuteAfterDatabaseSynchronous(sparrow);
            migration.SaveCurrentVersion(sparrow);
        }
    }
}
