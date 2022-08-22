using Mapster;
using MapsterMapper;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// Queryable扩展
    /// </summary>
    public static class QueryableExtension
    {

        /// <summary>
        /// 获取第一条数据并映射到指定类型
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static TDest First<TEntity, TDest>(this IQueryable<TEntity> condition)
        {
            return new Mapper().Map<TDest>(condition.First());
        }
        /// <summary>
        /// 获取第一条数据并映射到指定类型
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="config">映射配置</param>
        /// <returns></returns>
        public static TDest First<TEntity, TDest>(this IQueryable<TEntity> condition, TypeAdapterConfig config)
        {
            var data = condition.First();
            if (config is null)
            {
                return new Mapper().Map<TDest>(data);
            }
            else
            {
                var selfMapper = new Mapper(config);
                return selfMapper.Map<TDest>(data);
            }
        }

        /// <summary>
        /// 获取第一条数据并映射到指定类型
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static TDest FirstOrDefault<TEntity, TDest>(this IQueryable<TEntity> condition)
        {
            return new Mapper().Map<TDest>(condition.FirstOrDefault());
        }
        /// <summary>
        /// 获取第一条数据并映射到指定类型
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="config">映射配置</param>
        /// <returns></returns>
        public static TDest FirstOrDefault<TEntity, TDest>(this IQueryable<TEntity> condition, TypeAdapterConfig config)
        {
            var data = condition.FirstOrDefault();
            if (config is null)
            {
                return new Mapper().Map<TDest>(data);
            }
            else
            {
                var selfMapper = new Mapper(config);
                return selfMapper.Map<TDest>(data);
            }
        }

        /// <summary>
        /// 获取数据列表并映射到指定类型列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static List<TDest> ToList<TEntity, TDest>(this IQueryable<TEntity> condition)
        {
            return new Mapper().Map<List<TDest>>(condition.ToList());
        }

        /// <summary>
        /// 获取数据列表并映射到指定类型列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="config">映射配置</param>
        /// <returns></returns>
        public static List<TDest> ToList<TEntity, TDest>(this IQueryable<TEntity> condition, TypeAdapterConfig config)
        {
            var data = condition.ToList();
            if (config is null)
            {
                return new Mapper().Map<List<TDest>>(data);
            }
            else
            {
                var selfMapper = new Mapper(config);
                return selfMapper.Map<List<TDest>>(data);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <returns></returns>
        public static IList<TEntity> ToPagination<TEntity>(this IQueryable<TEntity> condition, int index, int size)
        {
            return condition.Skip((index - 1) * size).Take(size).ToList();
        }

        /// <summary>
        /// 分页获取数据列表，并返回总数
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="count">总数</param>
        /// <returns></returns>
        public static IList<TEntity> ToPagination<TEntity>(this IQueryable<TEntity> condition, int index, int size, out int count)
        {
            count = condition.Count();
            return condition.Skip((index - 1) * size).Take(size).ToList();
        }

        /// <summary>
        /// 分页获取数据列表并映射到指定类型列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <returns></returns>
        public static IList<TDest> ToPagination<TEntity, TDest>(this IQueryable<TEntity> condition, int index, int size)
        {
            var pagination = ToPagination(condition, index, size);
            return new Mapper().Map<List<TDest>>(pagination);
        }

        /// <summary>
        /// 分页获取数据列表并映射到指定类型列表，并返回总数
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="count">总数</param>
        /// <returns></returns>
        public static IList<TDest> ToPagination<TEntity, TDest>(this IQueryable<TEntity> condition, int index, int size, out int count)
        {
            var pagination = ToPagination(condition, index, size, out count);
            return new Mapper().Map<List<TDest>>(pagination);
        }

        /// <summary>
        /// 分页获取数据列表并映射到指定类型列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="config">映射配置</param>
        /// <returns></returns>
        public static IList<TDest> ToPagination<TEntity, TDest>(this IQueryable<TEntity> condition, int index, int size, TypeAdapterConfig config)
        {
            var pagination = ToPagination(condition, index, size);
            IList<TDest> list;
            if (config is null)
            {
                list = new Mapper().Map<List<TDest>>(pagination);
            }
            else
            {
                var selfMapper = new Mapper(config);
                list = selfMapper.Map<List<TDest>>(pagination);
            }
            return list;
        }

        /// <summary>
        /// 分页获取数据列表并映射到指定类型列表，并返回总数
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="config">映射配置</param>
        /// <param name="count">总数</param>
        /// <returns></returns>
        public static IList<TDest> ToPagination<TEntity, TDest>(this IQueryable<TEntity> condition, int index, int size, TypeAdapterConfig config, out int count)
        {
            var pagination = ToPagination(condition, index, size, out count);
            IList<TDest> list;
            if (config is null)
            {
                list = new Mapper().Map<List<TDest>>(pagination);
            }
            else
            {
                var selfMapper = new Mapper(config);
                list = selfMapper.Map<List<TDest>>(pagination);
            }
            return list;
        }
    }
}
