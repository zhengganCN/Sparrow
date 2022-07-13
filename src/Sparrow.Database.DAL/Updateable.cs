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
    public class Updateable<TEntity> where TEntity : class, new()
    {
        internal readonly Dictionary<string, object> properties = new Dictionary<string, object>();
        internal IQueryable<TEntity> Condition { get; private set; }

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
            if (binary.Left is MemberExpression && binary.Right is ConstantExpression)
            {
                var member = binary.Left as MemberExpression;
                var constant = binary.Right as ConstantExpression;
                SetPropertyValueForEntity(member, constant);
            }
            else if (binary.Right is MemberExpression && binary.Left is ConstantExpression)
            {
                var constant = binary.Left as ConstantExpression;
                var member = binary.Right as MemberExpression;
                SetPropertyValueForEntity(member, constant);
            }
            else
            {
                throw new ArgumentException(nameof(column));
            }
            return this;
        }

        /// <summary>
        /// 设置更新条件
        /// </summary>
        /// <returns></returns>
        public Updateable<TEntity> SetUpdateCondition(IQueryable<TEntity> condition)
        {
            Condition = condition;
            return this;
        }

        private void SetPropertyValueForEntity(MemberExpression member, ConstantExpression constant)
        {
            var name = member.Member.Name;
            var value = constant.Value;
            if (properties.TryGetValue(name, out _))
            {
                properties[name] = value;
            }
            else
            {
                properties.Add(name, value);
            }
        }
    }
}
