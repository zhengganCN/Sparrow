using System;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 页首参数
    /// </summary>
    public class Header
    {
        /// <summary>
        /// 页码参数
        /// </summary>
        internal readonly PageNumber PageNumber = new PageNumber(true);
        /// <summary>
        /// 设置页码参数
        /// </summary>
        /// <param name="action">参数</param>
        /// <returns></returns>
        public Header SetPageNumber(Action<PageNumber> action)
        {
            action.Invoke(PageNumber);
            return this;
        }
    }
}
