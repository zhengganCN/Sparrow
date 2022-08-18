using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Sparrow.Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        /// <param name="services">服务集合</param>
        /// <param name="assemblies">IDAL实现类所处的程序集</param>
        /// <returns></returns>
        public static IServiceCollection AddDAL<TDbContext>(this IServiceCollection services, Assembly[] assemblies = null)
            where TDbContext : DbContext
        {
            services.AddSingleton<IMapper, Mapper>();
            services.AddDbContext<TDbContext>();
            services.AddScoped<BaseDAL<TDbContext>>();
            services.AddScoped<DALFactory>();
            services.AddScoped<IDALFactory, DALFactory>();
            Register(services, assemblies);
            return services;
        }

        private static void Register(IServiceCollection services, Assembly[] assemblies)
        {
            if (assemblies is null || !assemblies.Any())
            {
                return;
            }
            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Any(e => e.Name == nameof(IDAL)))
                    {
                        types.Add(type);
                    }
                }
            }
            foreach (var type in types)
            {
                if (!type.IsClass)
                {
                    continue;
                }
                services.AddScoped(type);
            }
        }
    }
}
