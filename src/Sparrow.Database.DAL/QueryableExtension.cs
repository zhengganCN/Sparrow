using Mapster;
using MapsterMapper;
using System;
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
        public static Pagination<TEntity> ToPagination<TEntity>(this IQueryable<TEntity> condition, int index, int size)
        {
            var count = condition.Count();
            var list = condition.Skip((index - 1) * size).Take(size).ToList();
            return new Pagination<TEntity>
            {
                List = list,
                PageSize = size,
                PageCount = (int)Math.Ceiling((double)count / size),
                PageIndex = index,
                Count = count
            };
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
        public static Pagination<TDest> ToPagination<TEntity, TDest>(this IQueryable<TEntity> condition, int index, int size)
        {
            var pagination = ToPagination(condition, index, size);
            return new Pagination<TDest>
            {
                PageCount = pagination.PageCount,
                PageIndex = pagination.PageIndex,
                Count = pagination.Count,
                PageSize = pagination.PageSize,
                List = new Mapper().Map<List<TDest>>(pagination.List)
            };
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
        public static Pagination<TDest> ToPagination<TEntity, TDest>(this IQueryable<TEntity> condition, int index, int size, TypeAdapterConfig config)
        {
            var pagination = ToPagination(condition, index, size);
            List<TDest> list;
            if (config is null)
            {
                list = new Mapper().Map<List<TDest>>(pagination.List);
            }
            else
            {
                var selfMapper = new Mapper(config);
                list = selfMapper.Map<List<TDest>>(pagination.List);
            }
            return new Pagination<TDest>
            {
                PageCount = pagination.PageCount,
                PageIndex = pagination.PageIndex,
                Count = pagination.Count,
                PageSize = pagination.PageSize,
                List = list
            };
        }
    }
}
