﻿using System;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// Base输出
    /// </summary>
    public abstract class BaseDto
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// 跟踪ID
        /// </summary>
        public string TraceId { get; internal set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 时间
        /// </summary>
        public object Time { get; set; }
        /// <summary>
        /// 错误列表
        /// </summary>
        public string[] Errors { get; set; }
    }
}
