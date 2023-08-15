using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Monitor.Http
{
    public class HttpRecorder
    {
        internal static Func<HttpContext, string> FormatHttpContextFunc { get; set; }
        internal static Action<string> RecordStringAction { get; set; }
        public static Task Record(HttpContext context)
        {
            return Task.Run(() =>
            {
                var record = string.Empty;
                if (FormatHttpContextFunc == null)
                {
                    record = GetDefaultFormatHttpContext(context);
                }
                else
                {
                    record = FormatHttpContextFunc.Invoke(context);
                }
                if (RecordStringAction == null)
                {
                    DefaultRecordString(record);
                }
                else
                {
                    RecordStringAction.Invoke(record);
                }
            });
        }

        private static string GetDefaultFormatHttpContext(HttpContext context)
        {
            var builder = new StringBuilder();
            builder.AppendLine(context.Request.QueryString.ToString());
            builder.AppendLine(context.Connection.Id);
            builder.AppendLine(context.Connection.LocalPort.ToString());
            return builder.ToString();
        }

        private static void DefaultRecordString(string record)
        {
            Console.WriteLine(record);
        }
    }
}
