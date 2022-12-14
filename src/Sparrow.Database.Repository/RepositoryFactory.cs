using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sparrow.Database.Repository
{
    /// <summary>
    /// 仓储工厂
    /// </summary>
    public class RepositoryFactory
    {
        private readonly IServiceProvider _provider;

        public RepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// 获取Repository
        /// </summary>
        /// <typeparam name="TRepository">Repository</typeparam>
        /// <returns></returns>
        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            return _provider.GetService<TRepository>();
        }
    }
}
