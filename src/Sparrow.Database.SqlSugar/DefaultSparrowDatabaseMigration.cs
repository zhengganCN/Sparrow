using Sparrow.Database.Interface;
using Sparrow.Database.Migration;
using SqlSugar;
using System.Reflection;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 默认<see cref="ISparrowDatabaseMigration{T}"/>实现
    /// </summary>
    /// <typeparam name="D">数据库上下文</typeparam>
    /// <typeparam name="V">实现<see cref="ISparrowVersion"/>接口的版本表</typeparam>
    public class DefaultSparrowDatabaseMigration<D, V> : ISparrowDatabaseMigration<V>
        where D : IDbContext, new()
        where V : class, ISparrowVersion, new()
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public DbContext Context { get; private set; }
        /// <summary>
        /// 初始化
        /// </summary>
        public DefaultSparrowDatabaseMigration()
        {
            Context = new D() as DbContext;
        }
        /// <summary>
        /// 判断版本表是否存在
        /// </summary>
        /// <returns></returns>
        public virtual bool ExistVersionTable()
        {
            string name;
            var type = typeof(V);
            var sugarTable = type.GetCustomAttribute<SugarTable>();
            if (sugarTable == null)
            {
                name = type.Name;
            }
            else
            {
                name = sugarTable.TableName;
            }
            return Context.SugarClient.DbMaintenance.IsAnyTable(name);
        }
        /// <summary>
        /// 获取当前版本
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public virtual ISparrowVersion GetCurrentVersion(string name)
        {
            return Context.SugarClient.Queryable<V>()
                    .Where(e => e.Name == name)
                    .OrderBy(e => e.Major, OrderByType.Desc)
                    .OrderBy(e => e.Minor, OrderByType.Desc)
                    .OrderBy(e => e.Revision, OrderByType.Desc)
                    .OrderBy(e => e.Temporary, OrderByType.Desc)
                    .First();
        }
        /// <summary>
        /// 保存当前版本
        /// </summary>
        /// <param name="version"></param>
        public virtual void SaveCurrentVersion(V version)
        {
            Context.SugarClient.Insertable(version).ExecuteCommand();
        }
        /// <summary>
        /// 在表同步之前执行
        /// </summary>
        public virtual void ExcuteBeforeDatabaseSynchronous()
        {
        }
        /// <summary>
        /// 表同步执行
        /// </summary>
        public virtual void ExcuteDatabaseSynchronous()
        {
            Context.SugarClient.CodeFirst.InitTables(typeof(V));
        }
        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        public virtual void ExcuteAfterDatabaseSynchronous()
        {
        }
    }
}
