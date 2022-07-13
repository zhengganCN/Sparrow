using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// 数据访问基类
    /// </summary>
    public class BaseDAL<TDbContext> where TDbContext : DbContext
    {
        internal readonly TDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public BaseDAL(TDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Add<TEntity>(TEntity entity) where TEntity : class
        {            
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }
        /// <summary>
        /// 添加数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int Add<TEntity>(List<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().AddRange(entities);
            return context.SaveChanges();
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Update(entity);
            return context.SaveChanges();
        }
        /// <summary>
        /// 修改数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int Update<TEntity>(List<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().UpdateRange(entities);
            return context.SaveChanges();
        }
        /// <summary>
        /// 按条件修改数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="updateable">更新条件</param>
        /// <returns></returns>
        public int Update<TEntity>(Updateable<TEntity> updateable) where TEntity : class, new()
        {
            var entities = ToList(updateable.Condition);
            if (entities?.Any() == true)
            {
                foreach (var entity in entities)
                {
                    foreach (var property in updateable.properties)
                    {
                        entity.GetType().GetProperty(property.Key)
                            .SetValue(entity, property.Value);
                    }
                }
            }
            return context.SaveChanges();
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        public int Delete<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges();
        }
        /// <summary>
        /// 删除数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">数据列表</param>
        /// <returns></returns>
        public int Delete<TEntity>(List<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().RemoveRange(entities);
            return context.SaveChanges();
        }
        /// <summary>
        /// 按条件删除数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="condition">删除条件</param>
        /// <returns></returns>
        public int Delete<TEntity>(IQueryable<TEntity> condition) where TEntity : class
        {
            var entities = ToList(condition);
            context.Set<TEntity>().RemoveRange(entities);
            return context.SaveChanges();
        }
        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public TEntity First<TEntity>(IQueryable<TEntity> condition) where TEntity : class
        {
            return condition.FirstOrDefault();
        }
        /// <summary>
        /// 获取第一条数据并映射到指定类型
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public TDest First<TEntity, TDest>(IQueryable<TEntity> condition) where TEntity : class
        {
            return mapper.Map<TDest>(First(condition));
        }
        /// <summary>
        /// 获取第一条数据并映射到指定类型
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="config">映射配置</param>
        /// <returns></returns>
        public TDest First<TEntity, TDest>(IQueryable<TEntity> condition, TypeAdapterConfig config)
            where TEntity : class
        {
            var data = First(condition);
            if (config is null)
            {
                return mapper.Map<TDest>(data);
            }
            else
            {
                var selfMapper = new Mapper(config);
                return selfMapper.Map<TDest>(data);
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public List<TEntity> ToList<TEntity>(IQueryable<TEntity> condition) where TEntity : class
        {
            return condition.ToList();
        }
        /// <summary>
        /// 获取数据列表并映射到指定类型列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public List<TDest> ToList<TEntity, TDest>(IQueryable<TEntity> condition) where TEntity : class
        {
            return mapper.Map<List<TDest>>(ToList(condition));
        }
        /// <summary>
        /// 获取数据列表并映射到指定类型列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TDest">映射类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="config">映射配置</param>
        /// <returns></returns>
        public List<TDest> ToList<TEntity, TDest>(IQueryable<TEntity> condition, TypeAdapterConfig config) 
            where TEntity : class
        {
            var data = ToList(condition);
            if (config is null)
            {
                return mapper.Map<List<TDest>>(data);
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
        public Pagination<TEntity> ToPagination<TEntity>(IQueryable<TEntity> condition, int index, int size)
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
        public Pagination<TDest> ToPagination<TEntity, TDest>(IQueryable<TEntity> condition, int index, int size)
        {
            var pagination = ToPagination(condition, index, size);
            return new Pagination<TDest>
            {
                PageCount = pagination.PageCount,
                PageIndex = pagination.PageIndex,
                Count = pagination.Count,
                PageSize = pagination.PageSize,
                List = mapper.Map<List<TDest>>(pagination.List)
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
        public Pagination<TDest> ToPagination<TEntity, TDest>(IQueryable<TEntity> condition, int index, int size, TypeAdapterConfig config)
        {
            var pagination = ToPagination(condition, index, size);
            List<TDest> list;
            if (config is null)
            {
                list = mapper.Map<List<TDest>>(pagination.List);
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
