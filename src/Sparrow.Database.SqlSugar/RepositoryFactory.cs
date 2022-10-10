using Microsoft.Extensions.DependencyInjection;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 仓储工厂
    /// </summary>
    public class RepositoryFactory
    {

        /// <summary>
        /// 获取Repository
        /// </summary>
        /// <typeparam name="TRepository">Repository</typeparam>
        /// <returns></returns>
        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            return StaticValues.Services.BuildServiceProvider().GetService<TRepository>();
        }
    }
}
