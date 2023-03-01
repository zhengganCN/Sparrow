using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Sparrow.DataValidation
{
    /// <summary>
    /// 模型验证
    /// </summary>
    public class SparrowValidation
    {
        /// <summary>
        /// 是否验证通过
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static bool IsValid(object model, out SparrowValidationInfo[] errors)
        {
            errors = null;
            if (model is null)
            {
                return true;
            }
            var type = model.GetType();
            errors = Valid(type, model).ToArray();
            return errors.Length == 0;
        }

        private static bool IsObject(Type type)
        {
            if (type.IsClass || type.IsInterface)
            {
                return true;
            }
            return false;
        }

        private static bool IsValue(Type type)
        {
            return type.IsValueType;
        }

        private static List<SparrowValidationInfo> Valid(Type type, object model, string name = "")
        {
            var infos = new List<SparrowValidationInfo>();
            if (type == typeof(string) || IsValue(type)) { }
            else if (type.GetInterface(nameof(IEnumerable)) != null)
            {
                var list = model as IEnumerable<object>;
                foreach (var item in list)
                {
                    infos.AddRange(Valid(item.GetType(), item, name));
                }
            }
            else if (IsObject(type))
            {
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    string temp = property.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        temp = name + "." + temp;
                    }
                    infos.AddRange(Valid(property, model, temp));
                }
            }
            return infos;
        }

        private static List<SparrowValidationInfo> Valid(PropertyInfo property, object model, string name = "")
        {
            var infos = new List<SparrowValidationInfo>();
            if (property.PropertyType == typeof(string))
            {
                AddErrors(infos, GetValidationAttribute(property, model, name));
            }
            else if (property.PropertyType.GetInterface(nameof(IEnumerable)) != null)
            {
                AddErrors(infos, GetValidationAttribute(property, model, name));
                var list = property.GetValue(model) as IEnumerable<object>;
                if (list != null)
                {
                    var index = 0;
                    foreach (var item in list)
                    {
                        string temp = $"{name}[{index}]";
                        infos.AddRange(Valid(item.GetType(), item, temp));
                        index++;
                    }
                }
            }
            else if (IsObject(property.PropertyType))
            {
                var properties = property.PropertyType.GetProperties();
                var value = property.GetValue(model);
                foreach (var item in properties)
                {
                    string temp = item.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        temp = name + "." + temp;
                    }
                    infos.AddRange(Valid(item, value, temp));
                }
            }
            else if (IsValue(property.PropertyType))
            {
                AddErrors(infos, GetValidationAttribute(property, model, name));
            }
            return infos;
        }

        private static SparrowValidationInfo GetValidationAttribute(PropertyInfo property, object model, string name = "")
        {
            var validations = property.GetCustomAttributes<ValidationAttribute>();
            var errors = new List<string>();
            foreach (var validation in validations)
            {
                var value = property.GetValue(model);
                var result = validation.IsValid(value);
                if (!result)
                {
                    errors.Add(validation.FormatErrorMessage(property.Name));
                }
            }
            if (errors.Count == 0)
            {
                return null;
            }
            return new SparrowValidationInfo
            {
                Name = name,
                Errors = errors.ToArray()
            };
        }
        private static void AddErrors(List<SparrowValidationInfo> errors, SparrowValidationInfo error)
        {
            if (error != null)
            {
                errors.Add(error);
            }
        }
    }
}
