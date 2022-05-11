using System.Text;

namespace Sparrow.Convert.System
{
    public static partial class SparrowConvert
    {
        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="value">待处理字符</param>
        /// <returns></returns>
        public static string LowercaseFirstLetter(this string value)
        {
            return HandleString(value, StringCaseEnum.Lowercase);
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="value">待处理字符</param>
        /// <returns></returns>
        public static string UppercaseFirstLetter(this string value)
        {
            return HandleString(value, StringCaseEnum.Uppercase);
        }

        /// <summary>
        /// 字符处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="case"></param>
        /// <returns></returns>
        private static string HandleString(string value, StringCaseEnum @case)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            var builder = new StringBuilder(' ');
            builder.Append(value);
            bool isFirstLetterNextChar;
            for (int i = 0; i < builder.Length; i++)
            {
                if (builder[i] == ' ')
                {
                    isFirstLetterNextChar = true;
                }
                else
                {
                    isFirstLetterNextChar = false;
                }
                if (isFirstLetterNextChar && builder[i] != ' ')
                {
                    switch (@case)
                    {
                        case StringCaseEnum.Lowercase:
                            builder[i] = builder[i].ToString().ToLowerInvariant().ToCharArray()[0];
                            break;
                        case StringCaseEnum.Uppercase:
                            builder[i] = builder[i].ToString().ToUpperInvariant().ToCharArray()[0];
                            break;
                    }
                }
            }
            return builder.ToString();
        }
    }
}
