using Microsoft.AspNetCore.Mvc;

namespace Sparrow.StandardResult.Web
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class StandardControllerBase : ControllerBase
    {
        private readonly string _key;
        /// <summary>
        /// 初始化
        /// </summary>
        public StandardControllerBase(string key = "default-sparrow-standard-result")
        {
            _key = key;
        }
        /// <summary>
        /// 输出
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        protected Standard GetStandard()
        {
            return new Standard(_key);
        }

        /// <summary>
        /// 标准输出
        /// </summary>
        /// <param name="standard"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult StandardContent(Standard standard)
        {
            return new ContentResult
            {
                StatusCode = 200,
                Content = standard.Serialize(),
                ContentType = "application/json"
            };
        }
    }
}
