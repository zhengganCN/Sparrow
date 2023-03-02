using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sparrow.Configuration.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparrow.Configuration
{
    /// <summary>
    /// Configuration扩展
    /// </summary>
    public static class IConfigurationExtensions
    {
        /// <summary>
        /// 获取配置对象
        /// </summary>
        /// <param name="configuration">配置</param>
        /// <returns></returns>
        public static object GetObject(this IConfiguration configuration)
        {
            return configuration.GetObject<object>();
        }

        /// <summary>
        /// 获取配置对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="configuration">配置</param>
        /// <returns></returns>
        public static T GetObject<T>(this IConfiguration configuration)
        {
            var configs = configuration.AsEnumerable().ToList();
            var keys = configs
                .Where(e => e.Key.Split(':').Length == 1)
                .Select(e => e.Key)
                .ToList();
            configs = configs
                .Where(e => e.Value != null)
                .ToList();
            var builder = new StringBuilder();
            builder.Append("{");
            for (int i = 0; i < keys.Count; i++)
            {
                builder.Append("\"");
                builder.Append(keys[i]);
                builder.Append("\":");
                ConvertToJson(builder, keys[i], configs);
                if (i + 1 != keys.Count)
                {
                    builder.Append(",");
                }
            }
            builder.Append("}");
            return JsonConvert.DeserializeObject<T>(builder.ToString());
        }

        /// <summary>
        /// 获取配置对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="configuration">配置</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static T GetObject<T>(this IConfiguration configuration, string key)
        {
            var configs = configuration.AsEnumerable()
                .Where(e => e.Key == key || e.Key.StartsWith(key + ":"))
                .Where(e => e.Value != null)
                .ToList();
            var sb = new StringBuilder();
            ConvertToJson(sb, key, configs);
            return JsonConvert.DeserializeObject<T>(sb.ToString());
        }

        private static void ConvertToJson(StringBuilder builder, string key, List<KeyValuePair<string, string>> configs)
        {
            switch (ConfigObjType(key, configs))
            {
                case ObjectType.BasicObject:
                    BasicObject(builder, key, configs);
                    break;
                case ObjectType.ArrayObject:
                    ArrayObject(builder, key, configs);
                    break;
                case ObjectType.SimpleObject:
                    SimpleObject(builder, key, configs);
                    break;
                default:
                    break;
            }
        }

        private static void BasicObject(StringBuilder builder, string key, List<KeyValuePair<string, string>> configs)
        {
            builder.Append("\"");
            builder.Append(configs.First(e => e.Key == key).Value);
            builder.Append("\"");
        }

        private static void ArrayObject(StringBuilder builder, string key, List<KeyValuePair<string, string>> configs)
        {
            builder.Append("[");
            var index = 0;
            while (configs.Any(e => e.Key == $"{key}:{index}" || e.Key.StartsWith($"{key}:{index}:")))
            {
                ConvertToJson(builder, $"{key}:{index}", configs);
                builder.Append(",");
                index++;
            }
            if (index > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            builder.Append("]");
        }

        private static void SimpleObject(StringBuilder builder, string key, List<KeyValuePair<string, string>> configs)
        {
            builder.Append("{");
            var matchs = RemoveDuplicateKey(key, configs);
            for (int i = 0; i < matchs.Count; i++)
            {
                var splits = matchs[i].Split(':');
                builder.Append("\"");
                builder.Append(splits[splits.Length - 1]);
                builder.Append("\":");
                ConvertToJson(builder, matchs[i], configs);
                if (i + 1 != matchs.Count)
                {
                    builder.Append(",");
                }
            }
            builder.Append("}");
        }

        /// <summary>
        /// 去除重复key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="configs">配置</param>
        /// <returns></returns>
        private static List<string> RemoveDuplicateKey(string key, List<KeyValuePair<string, string>> configs)
        {
            var len = key.Split(':').Length;
            var matchs = configs
                .Where(e => e.Key.StartsWith(key + ":"))
                .Where(e => e.Key.Split(':').Length >= len + 1)
                .Select(e => e.Key)
                .ToList();
            var list = new List<string>();
            foreach (var item in matchs)
            {
                var splits = item.Split(':').Take(len + 1).ToArray();
                var value = "";
                for (int i = 0; i < splits.Count(); i++)
                {
                    value += splits[i];
                    if (i + 1 != splits.Count())
                    {
                        value += ":";
                    }
                }
                if (!list.Contains(value))
                {
                    list.Add(value);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取对象类型
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="configs">配置</param>
        /// <returns></returns>
        private static ObjectType? ConfigObjType(string key, List<KeyValuePair<string, string>> configs)
        {
            if (configs.Any(e => e.Key == key))
            {
                return ObjectType.BasicObject;
            }
            else if (configs.Any(e => e.Key == key + ":0") || configs.Any(e => e.Key.StartsWith(key + ":0")))
            {
                return ObjectType.ArrayObject;
            }
            else if (configs.Any(e => e.Key.StartsWith(key + ":")))
            {
                return ObjectType.SimpleObject;
            }
            return null;
        }
    }
}
