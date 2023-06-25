using Sparrow.Database.Interface;
using Sparrow.Database.Migration;

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
        /// <param name="sparrow">版本</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowDatabaseMigration<D, M, V>(this IServiceCollection services, ISparrowVersion sparrow)
            where D : IDbContext, new()
            where M : ISparrowDatabaseMigration<V>, new()
            where V : class, ISparrowVersion, new()
        {
            var migration = new M();
            if (migration.ExistVersionTable())
            {
                var version = migration.GetCurrentVersion(sparrow.Name);
                if (version == null || sparrow.Compare(version) == 1)
                {
                    ExcuteMigration(migration, sparrow);
                }
            }
            else
            {
                ExcuteMigration(migration, sparrow);
            }
            return services;
        }

        private static void ExcuteMigration<V>(ISparrowDatabaseMigration<V> migration, ISparrowVersion sparrow)
            where V : class, ISparrowVersion, new()
        {
            migration.ExcuteBeforeDatabaseSynchronous();
            migration.ExcuteDatabaseSynchronous();
            migration.ExcuteAfterDatabaseSynchronous();
            migration.SaveCurrentVersion((V)sparrow);
        }
    }
}
