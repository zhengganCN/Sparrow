using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Sparrow.Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

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
            services.AddScoped<DALFactory>();
            services.AddScoped<IDALFactory, DALFactory>();
            Register(services);
            return services;
        }

        private static void Register(IServiceCollection services)
        {
            var types = new List<Type>();
            var libraries = DependencyContext.Default.RuntimeLibraries
                .ToList();
            foreach (var library in libraries)
            {
                var name = new AssemblyName(library.Name);
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(name);
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
