using Sparrow.Database.Interface;
using Sparrow.Database.SqlSugar;
using Sparrow.Database.SqlSugar.Interfaces;
using Sparrow.Database.SqlSugar.Migrations;
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
        /// <param name="options">配置项</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowDatabaseMigration<M, D>(this IServiceCollection services, Action<MigrationOptions> options)
            where M : ISparrowDatabaseMigration, new()
            where D : IDbContext, new()
        {
            var migration = DatabaseStaticValue.MigrationOptions;
            options?.Invoke(migration);
            services.AddSparrowDatabaseMigration<M, D>(migration);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="options">配置项</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowDatabaseMigration<M, D>(this IServiceCollection services, MigrationOptions options)
            where M : ISparrowDatabaseMigration, new()
            where D : IDbContext, new()
        {
            if (string.IsNullOrWhiteSpace(options.SheetName))
            {
                options.SheetName = options.NamingScheme switch
                {
                    NamingScheme.Hump => "SparrowVersion",
                    NamingScheme.Snake => "sparrow_version",
                    _ => "SparrowVersion",
                };
            }
            if (string.IsNullOrWhiteSpace(options.Name))
            {
                options.Name = "database";
            }
            MigrationExecute.Execute<M, D>(options);
            return services;
        }
    }
}
