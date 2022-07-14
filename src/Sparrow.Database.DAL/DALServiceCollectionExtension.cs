using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Sparrow.Database.DAL;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// DAL ServiceCollection Extension
    /// </summary>
    public static class DALServiceCollectionExtension
    {
        /// <summary>
        /// 添加DAL
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDAL<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext
        {
            services.AddSingleton<IMapper, Mapper>();
            services.AddDbContext<TDbContext>();
            services.AddScoped<BaseDAL<TDbContext>>();
            return services;
        }
    }
}
