using Sparrow.Database.SqlSugar.Interfaces;
using System;

namespace Sparrow.Database.SqlSugar.Migrations
{
    /// <summary>
    /// 抽象定义视图语句类
    /// </summary>
    public abstract class AbstractSparrowDefineView : ISparrowDefineView
    {
        /// <summary>
        /// 定义视图SQL
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="name">视图名称</param>
        /// <param name="version">视图版本号</param>
        /// <returns>视图SQL语句</returns>
        public virtual string DefineView(DbContext context, out string name, out SparrowVersion version)
        {
            throw new NotImplementedException();
        }
    }
}
