using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
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

        public BaseDAL(TDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Add<TEntity>(TEntity entity) where TEntity : class
        {            
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public int Add<TEntity>(List<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().AddRange(entities);
            return context.SaveChanges();
        }

        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Update(entity);
            return context.SaveChanges();
        }

        public int Update<TEntity>(List<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().UpdateRange(entities);
            return context.SaveChanges();
        }

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

        public int Delete<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges();
        }

        public int Delete<TEntity>(List<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().RemoveRange(entities);
            return context.SaveChanges();
        }

        public int Delete<TEntity>(IQueryable<TEntity> condition) where TEntity : class
        {
            var entities = ToList(condition);
            context.Set<TEntity>().RemoveRange(entities);
            return context.SaveChanges();
        }

        public TEntity First<TEntity>(IQueryable<TEntity> condition) where TEntity : class
        {
            return condition.FirstOrDefault();
        }

        public TDest First<TEntity, TDest>(IQueryable<TEntity> condition) where TEntity : class
        {
            return mapper.Map<TDest>(First(condition));
        }

        public TDest First<TEntity, TDest>(IQueryable<TEntity> condition, TypeAdapterConfig config) 
            where TEntity : class 
            where TDest : class
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

        public List<TEntity> ToList<TEntity>(IQueryable<TEntity> condition) where TEntity : class
        {
            return condition.ToList();
        }

        public List<TDest> ToList<TEntity, TDest>(IQueryable<TEntity> condition) where TEntity : class
        {
            return mapper.Map<List<TDest>>(ToList(condition));
        }

        public List<TDest> ToList<TEntity, TDest>(IQueryable<TEntity> condition, TypeAdapterConfig config) 
            where TEntity : class
            where TDest : class
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
    }

}
