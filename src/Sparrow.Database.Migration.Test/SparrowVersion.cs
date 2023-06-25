namespace Sparrow.Database.Migration.Test
{
    internal class SparrowVersion : ISparrowVersion
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public SparrowVersion(ushort major, ushort minor, ushort revision, ushort temporary)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
            Temporary = temporary;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 主版本号
        /// </summary>
        public ushort Major { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        public ushort Minor { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        public ushort Revision { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        public ushort Temporary { get; set; }
    }
}
