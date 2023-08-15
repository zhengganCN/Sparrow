using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Monitor.Http
{
    /// <summary>
    /// http记录员中间件
    /// </summary>
    public class SparrowHttpRecorderMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// http记录员中间件
        /// </summary>
        /// <param name="next"></param>
        public SparrowHttpRecorderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            await HttpRecorder.Record(context);
            await _next(context);
        }
    }
}
