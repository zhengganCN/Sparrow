using Sparrow.StandardResult.Web;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// IApplicationBuilder扩展
    /// </summary>
    public static class StandardResultWebApplicationBuilderExtensions
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="app"></param>
        public static void UseStandardExceptionHandler(this IApplicationBuilder app)
        {
            app.UseStandardExceptionHandler(default);
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="app"></param>
        /// <param name="key"><see cref="StandardDto"/>构造函数中的key值</param>
        public static void UseStandardExceptionHandler(this IApplicationBuilder app, string key)
        {
            WebValues.StardandKey = key;
            app.UseExceptionHandler(WebValues.ErrorTemplatePath);
        }
    }
}
