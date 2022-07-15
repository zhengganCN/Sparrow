using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// DAL工厂接口
    /// </summary>
    public interface IDALFactory : IDisposable
    {
        /// <summary>
        /// 获取DAL实例
        /// </summary>
        /// <typeparam name="TDbContext">数据库上下文</typeparam>
        /// <typeparam name="TDAL"></typeparam>
        /// <returns></returns>
        TDAL GetDAL<TDbContext, TDAL>() where TDbContext : DbContext where TDAL : BaseDAL<TDbContext>;
    }
    /// <summary>
    /// DAL泛型工厂接口
    /// </summary>
    /// <typeparam name="TDbContext">数据库上下文</typeparam>
    public interface IDALFactory<TDbContext> : IDisposable where TDbContext : DbContext
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        TDbContext Context { get; }
        /// <summary>
        /// 获取DAL实例
        /// </summary>
        /// <typeparam name="TDAL"></typeparam>
        /// <returns></returns>
        TDAL GetDAL<TDAL>() where TDAL : BaseDAL<TDbContext>;
    }
    /// <summary>
    /// DAL工厂
    /// </summary>
    public class DALFactory : IDALFactory
    {
        private readonly IServiceProvider provider;

        /// <summary>
        /// 初始化
        /// </summary>
        public DALFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// 获取DAL实例
        /// </summary>
        /// <typeparam name="TDbContext">数据库上下文</typeparam>
        /// <typeparam name="TDAL"></typeparam>
        /// <returns></returns>
        public TDAL GetDAL<TDbContext, TDAL>() where TDbContext : DbContext where TDAL : BaseDAL<TDbContext>
        {
            return provider.GetService<TDAL>();
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
        }
    }
    /// <summary>
    /// DAL泛型工厂
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class DALFactory<TDbContext> : IDALFactory<TDbContext> where TDbContext : DbContext
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public TDbContext Context { get; }
        private readonly IServiceProvider provider;

        /// <summary>
        /// 初始化
        /// </summary>
        public DALFactory(TDbContext context, IServiceProvider provider)
        {
            Context = context;
            this.provider = provider;
        }

        /// <summary>
        /// 获取DAL实例
        /// </summary>
        /// <typeparam name="TDAL"></typeparam>
        /// <returns></returns>
        public TDAL GetDAL<TDAL>() where TDAL : BaseDAL<TDbContext>
        {
            return provider.GetService<TDAL>();
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
