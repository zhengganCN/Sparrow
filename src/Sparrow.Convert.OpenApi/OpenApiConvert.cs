using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using System.IO;
using System.Text;

namespace Sparrow.Convert.OpenApi
{
    /// <summary>
    /// OpenApi文档转换
    /// </summary>
    public static class OpenApiConvert
    {
        /// <summary>
        /// 转换成3.0的OpenApi版本
        /// </summary>
        /// <param name="json">OpenApi</param>
        /// <param name="encoding">编码</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string ConvertVersion3(string json, Encoding encoding, OpenApiFormat format = OpenApiFormat.Json)
        {
            var document = GetOpenApiDocument(json, encoding);
            return document.Serialize(OpenApiSpecVersion.OpenApi3_0, format);
        }

        /// <summary>
        /// 转换成2.0的OpenApi版本
        /// </summary>
        /// <param name="json">OpenApi</param>
        /// <param name="encoding">编码</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string ConvertVersion2(string json, Encoding encoding, OpenApiFormat format = OpenApiFormat.Json)
        {
            var document = GetOpenApiDocument(json, encoding);
            return document.Serialize(OpenApiSpecVersion.OpenApi2_0, format);
        }

        /// <summary>
        /// 获取OpenApi的实体模型
        /// </summary>
        /// <param name="json">OpenApi</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static OpenApiDocument GetOpenApiDocument(string json, Encoding encoding)
        {
            var buf = encoding.GetBytes(json);
            using (var ms = new MemoryStream())
            {
                ms.Write(buf, 0, buf.Length);
                ms.Position = 0;
                return new OpenApiStreamReader().Read(ms, out var diagnostic);
            }
        }
    }
}
