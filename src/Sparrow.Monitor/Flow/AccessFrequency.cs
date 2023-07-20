using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Sparrow.Monitor.Flow
{
    /// <summary>
    /// 访问频率
    /// </summary>
    public class AccessFrequency
    {
        /// <summary>
        /// 返回body
        /// </summary>
        /// <remarks>
        /// 默认值为  
        /// new ContentResult
        /// {
        ///     StatusCode = 429,
        ///     ContentType = MediaTypeNames.Text.Plain,
        ///     Content = "频繁访问"
        /// };
        /// </remarks>
        public IActionResult Result { get; set; } = new ContentResult
        {
            StatusCode = 429,
            ContentType = MediaTypeNames.Text.Plain,
            Content = "频繁访问"
        };
    }
}
