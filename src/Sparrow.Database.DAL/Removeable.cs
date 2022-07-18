using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// 删除
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Removeable<TEntity> where TEntity : class
    {
        internal readonly Dictionary<string, object> properties = new Dictionary<string, object>();
        private readonly DbContext Context;

        internal IQueryable<TEntity> Condition { get; private set; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        /// <param name="condition"></param>
        public Removeable(DbContext context, IQueryable<TEntity> condition)
        {
            Context = context;
            Condition = condition;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <returns></returns>
        public int ExecuteCommand()
        {
            var entities = Condition.ToList();
            if (!entities.Any())
            {
                return 0;
            }
            Context.Set<TEntity>().RemoveRange(entities);
            return Context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Removeable<TEntity> Append(TEntity element)
        {
            Condition = Condition.Append(element);
            return this;
        }


        /// <summary>
        /// Concatenates two sequences.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Removeable<TEntity> Concat(IEnumerable<TEntity> source)
        {
            Condition = Condition.Concat(source);
            return this;
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the type parameter's default value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <returns></returns>
        public Removeable<TEntity> DefaultIfEmpty()
        {
            Condition = Condition.DefaultIfEmpty();
            return this;
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the specified value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Removeable<TEntity> DefaultIfEmpty(TEntity defaultValue)
        {
            Condition = Condition.DefaultIfEmpty(defaultValue);
            return this;
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using the default equality comparer to compare values.
        /// </summary>
        /// <returns></returns>
        public Removeable<TEntity> Distinct()
        {
            Condition = Condition.Distinct();
            return this;
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified System.Collections.Generic.IEqualityComparer`1 to compare values.
        /// </summary>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public Removeable<TEntity> Distinct(IEqualityComparer<TEntity> comparer)
        {
            Condition = Condition.Distinct(comparer);
            return this;
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// <returns></returns>
        public Removeable<TEntity> Except(IEnumerable<TEntity> source)
        {
            Condition = Condition.Except(source);
            return this;
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the specified System.Collections.Generic.IEqualityComparer`1 to compare values.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public Removeable<TEntity> Except(IEnumerable<TEntity> source, IEqualityComparer<TEntity> comparer)
        {
            Condition = Condition.Except(source, comparer);
            return this;
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Removeable<TEntity> Intersect(IEnumerable<TEntity> source)
        {
            Condition = Condition.Intersect(source);
            return this;
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the specified System.Collections.Generic.IEqualityComparer`1 to compare values.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public Removeable<TEntity> Intersect(IEnumerable<TEntity> source, IEqualityComparer<TEntity> comparer)
        {
            Condition = Condition.Intersect(source, comparer);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Removeable<TEntity> Prepend(TEntity element)
        {
            Condition = Condition.Prepend(element);
            return this;
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <returns></returns>
        public Removeable<TEntity> Reverse()
        {
            Condition = Condition.Reverse();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Removeable<TEntity> SkipLast(int count)
        {
            Condition = Condition.SkipLast(count);
            return this;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Removeable<TEntity> SkipWhile(Expression<Func<TEntity, bool>> predicate)
        {
            Condition = Condition.SkipWhile(predicate);
            return this;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Removeable<TEntity> SkipWhile(Expression<Func<TEntity, int, bool>> predicate)
        {
            Condition = Condition.SkipWhile(predicate);
            return this;
        }

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Removeable<TEntity> Skip(int count)
        {
            Condition = Condition.Skip(count);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Removeable<TEntity> TakeLast(int count)
        {
            Condition = Condition.TakeLast(count);
            return this;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Removeable<TEntity> TakeWhile(Expression<Func<TEntity, bool>> predicate)
        {
            Condition = Condition.TakeWhile(predicate);
            return this;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Removeable<TEntity> TakeWhile(Expression<Func<TEntity, int, bool>> predicate)
        {
            Condition = Condition.TakeWhile(predicate);
            return this;
        }

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Removeable<TEntity> Take(int count)
        {
            Condition = Condition.Take(count);
            return this;
        }

        /// <summary>
        /// Produces the set union of two sequences by using the default equality comparer.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Removeable<TEntity> Union(IEnumerable<TEntity> source)
        {
            Condition = Condition.Union(source);
            return this;
        }

        /// <summary>
        /// Produces the set union of two sequences by using a specified System.Collections.Generic.IEqualityComparer`1.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public Removeable<TEntity> Union(IEnumerable<TEntity> source, IEqualityComparer<TEntity> comparer)
        {
            Condition = Condition.Union(source, comparer);
            return this;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Removeable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            Condition = Condition.Where(predicate);
            return this;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Removeable<TEntity> Where(Expression<Func<TEntity, int, bool>> predicate)
        {
            Condition = Condition.Where(predicate);
            return this;
        }
    }
}
