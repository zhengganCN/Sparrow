using System.IO;

namespace Sparrow.Compression
{
    internal class Util
    {
        /// <summary>
        /// 获取路径指向的是文件还是目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static EnumPathType GetPathType(string path)
        {
            var pathType = EnumPathType.NoExits;
            if (Directory.Exists(path))
            {
                pathType = EnumPathType.DirectoryPath;
            }
            else if (File.Exists(path))
            {
                pathType = EnumPathType.FilePath;
            }
            return pathType;
        }
    }
}
