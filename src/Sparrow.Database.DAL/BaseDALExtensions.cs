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
        public static IQueryable<T> GetQueryable<T>(this BaseDAL<DbContext> dal) where T : class
        {
            return dal.context.Set<T>().AsQueryable();
        }

        public static Updateable<T> GetUpdateable<T>(this BaseDAL<DbContext> dal) where T : class,new()
        {
            return new Updateable<T>();
        }
    }
}
