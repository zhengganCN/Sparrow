using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp.Models
{
    /// <summary>
    /// 目录
    /// </summary>
    public class Catalogue
    {
        internal Catalogue() { }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 链接到的页面号码
        /// </summary>
        public int LinkPageNumber { get; set; }
        /// <summary>
        /// 子目录
        /// </summary>
        public List<Catalogue> Children { get; private set; } = new List<Catalogue>();
    }
}
