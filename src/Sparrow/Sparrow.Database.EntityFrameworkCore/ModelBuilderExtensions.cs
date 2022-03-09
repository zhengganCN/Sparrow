using Sparrow.Database.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

namespace Microsoft.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// 创建表的字段说明
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        /// <param name="modelBuilder">模型构造器</param>
        public static void ColumnCommentCreating(this ModelBuilder modelBuilder, DbContext dbContext)
        {
            var tablesOrViews = dbContext.GetType().GetProperties();//获取DbContext的所有属性
            foreach (var tableOrView in tablesOrViews)
            {
                if (tableOrView.PropertyType.IsGenericType)//判断属性是否是泛型类型，如果是，就判断为DbSet<T>
                {
                    foreach (var tableOrViewType in tableOrView.PropertyType.GetGenericArguments())//获取泛型类型的参数类型，且该参数类型的类型名为表或视图名称
                    {
                        if (tableOrView.GetCustomAttribute(typeof(DatabaseViewAttribute)) != null)//判断该类型是否是一个视图
                        {
                            modelBuilder.Entity(tableOrViewType).ToView(tableOrViewType.Name);//标记该类型是一个视图
                        }
                        else
                        {
                            foreach (var property in tableOrViewType.GetProperties())//获取表的所有字段
                            {
                                var desc = property.GetCustomAttribute(typeof(DescriptionAttribute));//获取字段的描述属性
                                if (desc != null)//字段的描述属性不为null
                                {
                                    var description = (desc as DescriptionAttribute).Description;
                                    modelBuilder.Entity(tableOrViewType).Property(property.PropertyType, property.Name).HasComment(description);// 为该字段的说明赋值
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 创建表或视图的说明
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        /// <param name="modelBuilder">模型构造器</param>
        public static void TableOrViewCommentCreating(this ModelBuilder modelBuilder, DbContext dbContext)
        {
            var tablesOrViews = dbContext.GetType().GetProperties();//获取DbContext的所有属性
            foreach (var tableOrView in tablesOrViews)
            {
                if (tableOrView.PropertyType.IsGenericType)//判断属性是否是泛型类型，如果是，就判断为DbSet<T>
                {
                    foreach (var tableOrViewType in tableOrView.PropertyType.GetGenericArguments())//获取泛型类型的参数类型，且该参数类型的类型名为表或视图名称
                    {
                        var description = tableOrViewType.GetCustomAttribute(typeof(DescriptionAttribute));
                        if (tableOrView.GetCustomAttribute(typeof(DatabaseViewAttribute)) != null)//判断DbSet<T>是否是一个视图
                        {
                            var entityTypeBuilder = modelBuilder.Entity(tableOrViewType).ToView(tableOrViewType.Name);//标记该类型是一个视图
                            if (description != null)
                            {
                                entityTypeBuilder.HasComment((description as DescriptionAttribute)?.Description);
                            }
                        }
                        else if (description != null)
                        {
                            modelBuilder.Entity(tableOrViewType).HasComment((description as DescriptionAttribute)?.Description);
                        }
                    }
                }
            }
        }
    }
}
