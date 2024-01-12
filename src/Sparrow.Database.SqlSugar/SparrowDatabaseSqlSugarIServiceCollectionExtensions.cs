using Sparrow.Database.Interface;
using Sparrow.Database.SqlSugar.Interfaces;
using Sparrow.Database.SqlSugar.Models;

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
        /// <param name="version">版本信息</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowDatabaseMigration<M, D>(this IServiceCollection services, SparrowVersion version)
            where M : ISparrowDatabaseMigration, new()
            where D : IDbContext, new()
        {
            new M().Execute<D>(version);
            return services;
        }
        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="version">版本信息</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowDatabaseMigration<M, D>(this IServiceCollection services, sparrow_version version)
            where M : ISparrowDatabaseMigration, new()
            where D : IDbContext, new()
        {
            new M().Execute<D>(version);
            return services;
        }
        /// <summary>
        /// 数据库迁移
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="version">版本信息</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowDatabaseMigration<M, D>(this IServiceCollection services, object version)
            where M : ISparrowDatabaseMigration, new()
            where D : IDbContext, new()
        {
            new M().Execute<D>(version);
            return services;
        }
    }
}
