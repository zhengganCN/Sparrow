using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// DAL工厂接口
    /// </summary>
    public interface IDALFactory
    {
        /// <summary>
        /// 获取DAL实例
        /// </summary>
        /// <typeparam name="TDAL">实现IDAL接口的类</typeparam>
        /// <returns></returns>
        TDAL GetDAL<TDAL>() where TDAL : IDAL;
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
        /// <typeparam name="TDAL">实现IDAL接口的类</typeparam>
        /// <returns></returns>
        public TDAL GetDAL<TDAL>() where TDAL : IDAL
        {
            return provider.GetService<TDAL>();
        }
    }
}
