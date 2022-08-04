using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// 更新条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class Updateable<TEntity> where TEntity : class
    {
        internal readonly Dictionary<string, object> properties = new Dictionary<string, object>();
        private readonly DbContext Context;
        internal IQueryable<TEntity> Condition { get; private set; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        /// <param name="condition"></param>
        public Updateable(DbContext context, IQueryable<TEntity> condition)
        {
            Condition = condition;
            Context = context;
        }

        /// <summary>
        /// 设置更新字段
        /// </summary>
        /// <param name="column">设置字段值</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">参数异常</exception>
        public Updateable<TEntity> SetColumn(Expression<Func<TEntity, bool>> column)
        {
            if (column is null)
            {
                throw new ArgumentNullException(nameof(column));
            }
            if (!(column.Body is BinaryExpression binary))
            {
                throw new ArgumentException(nameof(column));
            }
            object value = null;
            if (IsParameter(binary.Left, out string name))
            {
                value = Expression.Lambda(binary.Right).Compile().DynamicInvoke();
            }
            else if(IsParameter(binary.Right, out name))
            {
                value = Expression.Lambda(binary.Left).Compile().DynamicInvoke();
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (properties.TryGetValue(name, out _))
                {
                    properties[name] = value;
                }
                else
                {
                    properties.Add(name, value);
                }
            }
            return this;
        }

        private static bool IsParameter(Expression expression,out string name)
        {
            name = default;
            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                if (!(expression is MemberExpression member))
                {
                    return false;
                }
                else
                {
                    if (member.Expression.NodeType == ExpressionType.Parameter)
                    {
                        name = member.Member.Name;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
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
            foreach (var entity in entities)
            {
                foreach (var property in properties)
                {
                    entity.GetType().GetProperty(property.Key).SetValue(entity, property.Value);
                }
            }
            Context.Set<TEntity>().UpdateRange(entities);
            return Context.SaveChanges();
        }       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Updateable<TEntity> Append(TEntity element)
        {
            Condition = Condition.Append(element);
            return this;
        }

        /// <summary>
        /// Concatenates two sequences.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Updateable<TEntity> Concat(IEnumerable<TEntity> source)
        {
            Condition = Condition.Concat(source);
            return this;
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the type parameter's default value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <returns></returns>
        public Updateable<TEntity> DefaultIfEmpty()
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
        public Updateable<TEntity> DefaultIfEmpty(TEntity defaultValue)
        {
            Condition = Condition.DefaultIfEmpty(defaultValue);
            return this;
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using the default equality comparer to compare values.
        /// </summary>
        /// <returns></returns>
        public Updateable<TEntity> Distinct()
        {
            Condition = Condition.Distinct();
            return this;
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified System.Collections.Generic.IEqualityComparer`1 to compare values.
        /// </summary>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public Updateable<TEntity> Distinct(IEqualityComparer<TEntity> comparer)
        {
            Condition = Condition.Distinct(comparer);
            return this;
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// <returns></returns>
        public Updateable<TEntity> Except(IEnumerable<TEntity> source)
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
        public Updateable<TEntity> Except(IEnumerable<TEntity> source, IEqualityComparer<TEntity> comparer)
        {
            Condition = Condition.Except(source, comparer);
            return this;
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Updateable<TEntity> Intersect(IEnumerable<TEntity> source)
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
        public Updateable<TEntity> Intersect(IEnumerable<TEntity> source, IEqualityComparer<TEntity> comparer)
        {
            Condition = Condition.Intersect(source, comparer);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Updateable<TEntity> Prepend(TEntity element)
        {
            Condition = Condition.Prepend(element);
            return this;
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <returns></returns>
        public Updateable<TEntity> Reverse()
        {
            Condition = Condition.Reverse();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Updateable<TEntity> SkipLast(int count)
        {
            Condition = Condition.SkipLast(count);
            return this;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Updateable<TEntity> SkipWhile(Expression<Func<TEntity, bool>> predicate)
        {
            Condition = Condition.SkipWhile(predicate);
            return this;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Updateable<TEntity> SkipWhile(Expression<Func<TEntity, int, bool>> predicate)
        {
            Condition = Condition.SkipWhile(predicate);
            return this;
        }

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Updateable<TEntity> Skip(int count)
        {
            Condition = Condition.Skip(count);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Updateable<TEntity> TakeLast(int count)
        {
            Condition = Condition.TakeLast(count);
            return this;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Updateable<TEntity> TakeWhile(Expression<Func<TEntity, bool>> predicate)
        {
            Condition = Condition.TakeWhile(predicate);
            return this;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Updateable<TEntity> TakeWhile(Expression<Func<TEntity, int, bool>> predicate)
        {
            Condition = Condition.TakeWhile(predicate);
            return this;
        }

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Updateable<TEntity> Take(int count)
        {
            Condition = Condition.Take(count);
            return this;
        }

        /// <summary>
        /// Produces the set union of two sequences by using the default equality comparer.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Updateable<TEntity> Union(IEnumerable<TEntity> source)
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
        public Updateable<TEntity> Union(IEnumerable<TEntity> source, IEqualityComparer<TEntity> comparer)
        {
            Condition = Condition.Union(source, comparer);
            return this;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Updateable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            Condition = Condition.Where(predicate);
            return this;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Updateable<TEntity> Where(Expression<Func<TEntity, int, bool>> predicate)
        {
            Condition = Condition.Where(predicate);
            return this;
        }
    }
}
