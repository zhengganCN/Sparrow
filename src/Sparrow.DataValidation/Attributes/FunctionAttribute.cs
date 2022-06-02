using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 自定义函数验证接口
    /// </summary>
    public interface IFunction
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
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FunctionAttribute : ValidationAttribute
    {
        private readonly IFunction ValidClass;
        /// <summary>
        /// 自定义函数验证
        /// </summary>
        /// <param name="type">必须实现<see cref="IFunction"/>接口</param>
        /// <exception cref="ArgumentException"></exception>
        public FunctionAttribute(Type type)
        {
            if (type.GetInterface(nameof(IFunction)) is null)
            {
                throw new ArgumentException("未实现IFunction接口");
            }
            ValidClass = Activator.CreateInstance(type) as IFunction;
        }

        public override bool IsValid(object value)
        {            
            return ValidClass.Valid(value);
        }
    }
}
