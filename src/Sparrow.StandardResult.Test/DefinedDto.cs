using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult.Test
{
#pragma warning disable IDE1006 // 命名样式
    internal class DefinedDto
    {
        public string defined_code { get; set; }
        public string defined_message { get; set; }
        public object defined_data { get; set; }
        public bool defined_success { get; set; }
        public object defined_time { get; set; }
        public string defined_traceid { get; set; }
    }
    internal class OtherDto
    {
        public string other_code { get; set; }
        public string other_message { get; set; }
        public object other_data { get; set; }
        public bool other_success { get; set; }
        public object other_time { get; set; }
        public string other_traceid { get; set; }
    }
#pragma warning restore IDE1006 // 命名样式
}
