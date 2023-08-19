using SqlSugar;
using System.Collections.Generic;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 数据集
    /// </summary>
    public class DbSet<T> where T : class, new()
    {
        private readonly ISqlSugarClient _client;
        /// <summary>
        /// 数据集
        /// </summary>
        public DbSet()
        {
        }
        /// <summary>
        /// 数据集
        /// </summary>
        /// <param name="client">客户端</param>
        public DbSet(ISqlSugarClient client)
        {
            _client = client;
        }
        /// <summary>
        /// 查询
        /// </summary>
        public ISugarQueryable<T> Queryable
        {
            get
            {
                return _client.Queryable<T>();
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        public IUpdateable<T> Updateable
        {
            get
            {
                return _client.Updateable<T>();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public IDeleteable<T> Deleteable
        {
            get
            {
                return _client.Deleteable<T>();
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="item">数据</param>
        /// <returns></returns>
        public int Insert(T item)
        {
            return _client.Insertable(item).ExecuteCommand();
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="items">数据列</param>
        /// <returns></returns>
        public int Insert(T[] items)
        {
            return _client.Insertable(items).ExecuteCommand();
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="items">数据列</param>
        /// <returns></returns>
        public int Insert(List<T> items)
        {
            return _client.Insertable(items).ExecuteCommand();
        }
    }
}
