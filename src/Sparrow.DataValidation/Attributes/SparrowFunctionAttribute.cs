using System;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 自定义函数验证接口
    /// </summary>
    public interface ISparrowFunction
    {
        /// <summary>
        /// 自定义验证函数
        /// </summary>
        /// <param name="value">需验证的值</param>
        /// <returns></returns>
        bool Valid(object value);
    }

    /// <summary>
    /// 自定义函数验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class SparrowFunctionAttribute : ValidationAttribute
    {
        private readonly ISparrowFunction ValidClass;
        /// <summary>
        /// 自定义函数验证特性
        /// </summary>
        /// <param name="type">必须实现<see cref="ISparrowFunction"/>接口</param>
        /// <exception cref="ArgumentException"></exception>
        public SparrowFunctionAttribute(Type type)
        {
            if (type.GetInterface(nameof(ISparrowFunction)) is null)
            {
                throw new ArgumentException("未实现IFunction接口");
            }
            ValidClass = Activator.CreateInstance(type) as ISparrowFunction;
        }

        /// <summary>
        /// 重写验证逻辑
        /// </summary>
        /// <param name="value">验证值</param>
        /// <returns>是否验证通过</returns>
        public override bool IsValid(object value)
        {
            return ValidClass.Valid(value);
        }
    }
}
