using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// 数据访问基类
    /// </summary>
    public class BaseDAL<TDbContext> : IDisposable where TDbContext : DbContext
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public TDbContext Context { get; }
        /// <summary>
        /// 初始化
        /// </summary>
        public BaseDAL(TDbContext context)
        {
            Context = context;
        }
        /// <summary>
        /// 提供针对特定数据源评估查询的功能
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().AsQueryable();
        }
        /// <summary>
        /// 提供针对特定数据源评估更新的功能
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public Updateable<TEntity> AsUpdateable<TEntity>() where TEntity : class
        {
            return new Updateable<TEntity>(Context, AsQueryable<TEntity>());
        }

        /// <summary>
        /// 提供针对特定数据源评估删除的功能
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public Removeable<TEntity> AsRemoveable<TEntity>() where TEntity : class
        {
            return new Removeable<TEntity>(Context, AsQueryable<TEntity>());
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Add<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
            return Context.SaveChanges();
        }
        /// <summary>
        /// 添加数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Context.Set<TEntity>().AddRange(entities);
            return Context.SaveChanges();
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Update(entity);
            return Context.SaveChanges();
        }
        /// <summary>
        /// 修改数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Context.Set<TEntity>().UpdateRange(entities);
            return Context.SaveChanges();
        }
        
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Remove<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Remove(entity);
            return Context.SaveChanges();
        }
        /// <summary>
        /// 删除数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Context.Set<TEntity>().RemoveRange(entities);
            return Context.SaveChanges();
        }
        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }
    }

}
