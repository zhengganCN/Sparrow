using Microsoft.Extensions.DependencyInjection.Extensions;
using Sparrow.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Repository服务扩展
    /// </summary>
    public static class SparrowSqlSugarServiceCollectionExtension
    {
        /// <summary>
        /// 注册Repository
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddSparrowRepository(this IServiceCollection services, params Assembly[] assemblies)
        {
            RegisterRepository(services, assemblies);
            services.TryAddSingleton<RepositoryFactory>();
            return services;
        }

        private static void RegisterRepository(IServiceCollection services, Assembly[] assemblies)
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
                    if (type.IsAbstract)
                    {
                        continue;
                    }
                    var register = type.GetInterfaces()
                        .Where(e => e.Name == nameof(IRepository))
                        .Any();
                    if (register)
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
                services.TryAddScoped(type);
            }
        }
    }
}
