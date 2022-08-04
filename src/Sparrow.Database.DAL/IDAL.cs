using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// DAL接口
    /// </summary>
    public interface IDAL : IDisposable
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public DbContext GetDbContext();
        /// <summary>
        /// 提供针对特定数据源评估查询的功能
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class;
        /// <summary>
        /// 提供针对特定数据源评估更新的功能
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public Updateable<TEntity> AsUpdateable<TEntity>() where TEntity : class;
        /// <summary>
        /// 提供针对特定数据源评估删除的功能
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public Removeable<TEntity> AsRemoveable<TEntity>() where TEntity : class;
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Add<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 添加数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Update<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 修改数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Remove<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 删除数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    }
}
