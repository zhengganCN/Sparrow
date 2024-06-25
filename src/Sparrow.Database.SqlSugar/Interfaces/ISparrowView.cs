using Sparrow.Database.SqlSugar.Migrations;

namespace Sparrow.Database.SqlSugar.Interfaces
{
    /// <summary>
    /// 定义数据库视图接口
    /// </summary>
    public interface ISparrowView
    {
        /// <summary>
        /// 定义视图SQL
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="name">视图名称</param>
        /// <param name="version">视图版本号</param>
        /// <returns>视图SQL语句</returns>
        string DefineView(DbContext context, out string name, out SparrowVersion version);
    }
}
