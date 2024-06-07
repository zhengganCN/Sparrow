using System;
using System.Collections.Generic;
namespace Sparrow.StandardResult
{
    internal static class GenericTypeJudgment
    {
        /// <summary>
        /// 判断实例类型是否派生自StandardPagination
        /// </summary>
        /// <param name="instanceType"></param>
        /// <param name="isStandard"></param>
        /// <returns></returns>
        public static bool InheritStandardGenericType(Type instanceType, out bool isStandard)
        {
            isStandard = false;
            Type target = typeof(Standard);
            // 检查实例类型是否是泛型类型或其派生类型
            if (!instanceType.IsGenericType && !instanceType.IsConstructedGenericType)
            {
                return false;
            }
            if (instanceType.GetGenericTypeDefinition() == target)
            {
                isStandard = true;
                return true;
            }
            // 递归查找实例类型及其基类和接口
            Stack<Type> toCheck = new Stack<Type>();
            toCheck.Push(instanceType);

            while (toCheck.Count > 0)
            {
                Type currentType = toCheck.Pop();
                // 检查当前类型是否是目标泛型类型的实例或派生类
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == target)
                {
                    return true;
                }
                // 添加基类和接口以便后续检查
                foreach (Type baseType in currentType.GetInterfaces())
                {
                    if (baseType.IsConstructedGenericType && baseType.GetGenericTypeDefinition() == target)
                    {
                        return true;
                    }
                    toCheck.Push(baseType);
                }

                if (currentType.BaseType != null)
                {
                    toCheck.Push(currentType.BaseType);
                }
            }
            return false;
        }

        /// <summary>
        /// 判断实例类型是否派生自StandardPagination
        /// </summary>
        /// <param name="instanceType"></param>
        /// <param name="isStandardPagination"></param>
        /// <returns></returns>
        public static bool InheritStandardPaginationGenericType(Type instanceType, out bool isStandardPagination)
        {
            isStandardPagination = false;
            Type target = typeof(StandardPagination<>);
            // 检查实例类型是否是泛型类型或其派生类型
            if (!instanceType.IsGenericType && !instanceType.IsConstructedGenericType)
            {
                return false;
            }
            if (instanceType.GetGenericTypeDefinition() == target)
            {
                isStandardPagination = true;
                return true;
            }
            // 递归查找实例类型及其基类和接口
            Stack<Type> toCheck = new Stack<Type>();
            toCheck.Push(instanceType);

            while (toCheck.Count > 0)
            {
                Type currentType = toCheck.Pop();
                // 检查当前类型是否是目标泛型类型的实例或派生类
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == target)
                {
                    return true;
                }
                // 添加基类和接口以便后续检查
                foreach (Type baseType in currentType.GetInterfaces())
                {
                    if (baseType.IsConstructedGenericType && baseType.GetGenericTypeDefinition() == target)
                    {
                        return true;
                    }
                    toCheck.Push(baseType);
                }

                if (currentType.BaseType != null)
                {
                    toCheck.Push(currentType.BaseType);
                }
            }
            return false;
        }

    }
}
