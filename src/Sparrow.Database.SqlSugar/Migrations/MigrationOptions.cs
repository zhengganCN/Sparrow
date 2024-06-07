namespace Sparrow.Database.SqlSugar.Migrations
{
    /// <summary>
    /// 迁移选项
    /// </summary>
    public class MigrationOptions : SparrowVersion
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public MigrationOptions()
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public MigrationOptions(ushort major, string name = "database")
        {
            Major = major;
            Name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public MigrationOptions(ushort major, ushort minor, string name = "database")
        {
            Major = major;
            Minor = minor;
            Name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public MigrationOptions(ushort major, ushort minor, ushort revision, string name = "database")
        {
            Major = major;
            Minor = minor;
            Revision = revision;
            Name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public MigrationOptions(ushort major, ushort minor, ushort revision, ushort temporary, string name = "database")
        {
            Major = major;
            Minor = minor;
            Revision = revision;
            Temporary = temporary;
            Name = name;
        }
        /// <summary>
        /// 命名规则
        /// </summary>
        public NamingScheme NamingScheme { get; set; } = NamingScheme.Hump;
        /// <summary>
        /// 表名
        /// </summary>
        public string SheetName { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
