﻿using System;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 页底参数
    /// </summary>
    public class Footer
    {
        /// <summary>
        /// 页码参数
        /// </summary>
        internal readonly PageNumber PageNumber = new PageNumber(false);
        /// <summary>
        /// 设置页码参数
        /// </summary>
        /// <param name="action">参数</param>
        /// <returns></returns>
        public Footer SetPageNumber(Action<PageNumber> action)
        {
            action.Invoke(PageNumber);
            return this;
        }
    }
}
