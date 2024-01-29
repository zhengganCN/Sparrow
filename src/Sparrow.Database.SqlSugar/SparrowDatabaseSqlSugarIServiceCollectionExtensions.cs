using Sparrow.Database.Interface;
using Sparrow.Database.SqlSugar;
using Sparrow.Database.SqlSugar.Interfaces;
using Sparrow.Database.SqlSugar.Migrations;
using Sparrow.Database.SqlSugar.Models;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// <see cref="IServiceCollection"/>扩展
    /// </summary>
    public static class SparrowDatabaseSqlSugarIServiceCollectionExtensions
    {
        #region 
        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="major">主版本号</param>
        /// <param name="name">版本名称</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowHumpDatabaseMigration<M, D>(this IServiceCollection services, ushort major, string name = "database", string table = "SparrowVersion")
            where M : SparrowHumpDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowHumpDatabaseMigration<M, D>(options =>
            {
                options.major = major;
                options.name = name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="major">主版本号</param>
        /// <param name="minor">子版本号</param>
        /// <param name="name">版本名称</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowHumpDatabaseMigration<M, D>(this IServiceCollection services, ushort major, ushort minor, string name = "database", string table = "SparrowVersion")
            where M : SparrowHumpDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowHumpDatabaseMigration<M, D>(options =>
            {
                options.major = major;
                options.minor = minor;
                options.name = name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="major">主版本号</param>
        /// <param name="minor">子版本号</param>
        /// <param name="revision">修正版本号</param>
        /// <param name="name">版本名称</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowHumpDatabaseMigration<M, D>(this IServiceCollection services, ushort major, ushort minor, ushort revision, string name = "database", string table = "SparrowVersion")
            where M : SparrowHumpDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowHumpDatabaseMigration<M, D>(options =>
            {
                options.major = major;
                options.minor = minor;
                options.revision = revision;
                options.name = name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="major">主版本号</param>
        /// <param name="minor">子版本号</param>
        /// <param name="revision">修正版本号</param>
        /// <param name="temporary">临时版本号</param>
        /// <param name="name">版本名称</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowHumpDatabaseMigration<M, D>(this IServiceCollection services, ushort major, ushort minor, ushort revision, ushort temporary, string name = "database", string table = "SparrowVersion")
            where M : SparrowHumpDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowHumpDatabaseMigration<M, D>(options =>
            {
                options.major = major;
                options.minor = minor;
                options.revision = revision;
                options.temporary = temporary;
                options.name = name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="migration">配置项</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowHumpDatabaseMigration<M, D>(this IServiceCollection services, Migration migration, string table = "SparrowVersion")
            where M : SparrowHumpDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowHumpDatabaseMigration<M, D>(options =>
            {
                options.major = migration.major;
                options.minor = migration.minor;
                options.revision = migration.revision;
                options.temporary = migration.temporary;
                options.name = migration.name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="options">配置项</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowHumpDatabaseMigration<M, D>(this IServiceCollection services, Action<Migration> options, string table = "SparrowVersion")
            where M : SparrowHumpDatabaseMigration, new()
            where D : IDbContext, new()
        {
            var migration = DatabaseStaticValue.MigrationOptions;
            options?.Invoke(migration);
            if (string.IsNullOrWhiteSpace(migration.name))
            {
                migration.name = "database";
            }
            if (string.IsNullOrWhiteSpace(table))
            {
                table = "SparrowVersion";
            }
            migration.table_name = table;
            new M().Execute<D>(migration);
            return services;
        }
        #endregion
        #region 
        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="major">主版本号</param>
        /// <param name="name">版本名称</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowSnakeDatabaseMigration<M, D>(this IServiceCollection services, ushort major, string name = "database", string table = "sparrow_version")
            where M : SparrowSnakeDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowSnakeDatabaseMigration<M, D>(options =>
            {
                options.major = major;
                options.name = name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="major">主版本号</param>
        /// <param name="minor">子版本号</param>
        /// <param name="name">版本名称</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowSnakeDatabaseMigration<M, D>(this IServiceCollection services, ushort major, ushort minor, string name = "database", string table = "sparrow_version")
            where M : SparrowSnakeDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowSnakeDatabaseMigration<M, D>(options =>
            {
                options.major = major;
                options.minor = minor;
                options.name = name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="major">主版本号</param>
        /// <param name="minor">子版本号</param>
        /// <param name="revision">修正版本号</param>
        /// <param name="name">版本名称</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowSnakeDatabaseMigration<M, D>(this IServiceCollection services, ushort major, ushort minor, ushort revision, string name = "database", string table = "sparrow_version")
            where M : SparrowSnakeDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowSnakeDatabaseMigration<M, D>(options =>
            {
                options.major = major;
                options.minor = minor;
                options.revision = revision;
                options.name = name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="major">主版本号</param>
        /// <param name="minor">子版本号</param>
        /// <param name="revision">修正版本号</param>
        /// <param name="temporary">临时版本号</param>
        /// <param name="name">版本名称</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowSnakeDatabaseMigration<M, D>(this IServiceCollection services, ushort major, ushort minor, ushort revision, ushort temporary, string name = "database", string table = "sparrow_version")
            where M : SparrowSnakeDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowSnakeDatabaseMigration<M, D>(options =>
            {
                options.major = major;
                options.minor = minor;
                options.revision = revision;
                options.temporary = temporary;
                options.name = name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="migration">配置项</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowSnakeDatabaseMigration<M, D>(this IServiceCollection services, Migration migration, string table = "sparrow_version")
            where M : SparrowSnakeDatabaseMigration, new()
            where D : IDbContext, new()
        {
            services.AddSparrowSnakeDatabaseMigration<M, D>(options =>
            {
                options.major = migration.major;
                options.minor = migration.minor;
                options.revision = migration.revision;
                options.temporary = migration.temporary;
                options.name = migration.name;
            }, table);
            return services;
        }

        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="options">配置项</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowSnakeDatabaseMigration<M, D>(this IServiceCollection services, Action<Migration> options, string table = "sparrow_version")
            where M : SparrowSnakeDatabaseMigration, new()
            where D : IDbContext, new()
        {
            var migration = DatabaseStaticValue.MigrationOptions;
            options?.Invoke(migration);
            if (string.IsNullOrWhiteSpace(migration.name))
            {
                migration.name = "database";
            }
            if (string.IsNullOrWhiteSpace(table))
            {
                table = "sparrow_version";
            }
            migration.table_name = table;
            new M().Execute<D>(migration);
            return services;
        }
        #endregion
        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="options">配置项</param>
        /// <param name="table">版本表表名</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowDatabaseMigration<M, D>(this IServiceCollection services, Action<Migration> options, string table)
            where M : ISparrowDatabaseMigration, new()
            where D : IDbContext, new()
        {
            var migration = DatabaseStaticValue.MigrationOptions;
            options?.Invoke(migration);
            migration.table_name = table;
            new M().Execute<D>(migration);
            return services;
        }
    }
}
