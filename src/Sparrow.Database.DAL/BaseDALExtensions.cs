using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// BaseDAL扩展
    /// </summary>
    public static class BaseDALExtensions
    {
        /// <summary>
        /// 获取IQueryable实例
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="dal">BaseDAL实例</param>
        /// <returns></returns>
        public static IQueryable<TEntity> GetQueryable<TEntity>(this BaseDAL<DbContext> dal) where TEntity : class
        {
            return dal.context.Set<TEntity>().AsQueryable();
        }


        /// <summary>
        /// 获取Updateable实例
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="dal">BaseDAL实例</param>
        /// <returns></returns>
        public static Updateable<TEntity> GetUpdateable<TEntity>(this BaseDAL<DbContext> dal) where TEntity : class,new()
        {
            return new Updateable<TEntity>();
        }
    }
}
