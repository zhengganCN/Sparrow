using Sparrow.Database.Interface;
using Sparrow.Database.Migration;
using SqlSugar;
using System.Reflection;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 默认<see cref="ISparrowDatabaseMigration"/>实现
    /// </summary>
    /// <typeparam name="D">数据库上下文</typeparam>
    public class DefaultSparrowDatabaseMigration<D> : ISparrowDatabaseMigration
        where D : IDbContext, new()
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
        public virtual bool ExistVersionTable<V>() where V : class, ISparrowVersion, new()
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
        public virtual ISparrowVersion GetCurrentVersion<V>(string name) where V : class, ISparrowVersion, new()
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
        public virtual void SaveCurrentVersion<V>(V version) where V : class, ISparrowVersion, new()
        {
            if (ExistVersionTable<V>())
            {
                Context.SugarClient.Updateable(version)
                    .Where(e=>e.Name == version.Name)
                    .ExecuteCommand();
            }
            else
            {
                Context.SugarClient.Insertable(version).ExecuteCommand();
            }
        }
        /// <summary>
        /// 在表同步之前执行
        /// </summary>
        public virtual void ExcuteBeforeDatabaseSynchronous<V>(V version) where V : class, ISparrowVersion, new()
        {
        }
        /// <summary>
        /// 表同步执行
        /// </summary>
        public virtual void ExcuteDatabaseSynchronous<V>(V version) where V : class, ISparrowVersion, new()
        {
            Context.SugarClient.CodeFirst.InitTables(typeof(V));
        }
        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        public virtual void ExcuteAfterDatabaseSynchronous<V>(V version) where V : class, ISparrowVersion, new()
        {
        }
    }
}
