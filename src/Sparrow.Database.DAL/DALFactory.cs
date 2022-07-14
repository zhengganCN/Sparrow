using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// DAL工厂
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class DALFactory<TDbContext> : IDisposable where TDbContext : DbContext 
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
