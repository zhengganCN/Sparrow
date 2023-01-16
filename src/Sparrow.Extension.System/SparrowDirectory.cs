using System.Collections.Generic;
using System.IO;

namespace Sparrow.Extension.System
{
    /// <summary>
    /// 目录操作
    /// </summary>
    public static class SparrowDirectory
    {
        /// <summary>
        /// 获取文件夹路径
        /// </summary>
        /// <param name="path">根目录</param>
        /// <param name="deep">递归深度；当为null时或小于等于0时，不递归目录</param>
        /// <returns></returns>
        public static IList<string> GetDirectories(string path, uint deep)
        {
            var directoryPaths = Directory.GetDirectories(path);
            return GetDirectories(directoryPaths, deep);
        }

        /// <summary>
        /// 递归获取目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IList<string> GetDirectoriesByRecursive(string path)
        {
            var paths = new List<string>();
            var directories = Directory.GetDirectories(path);
            paths.AddRange(directories);
            foreach (var directory in directories)
            {
                paths.AddRange(GetDirectoriesByRecursive(directory));
            }
            return paths;
        }

        /// <summary>
        /// 获取文件夹路径
        /// </summary>
        /// <param name="directoryPaths">目录路径</param>
        /// <param name="deep">递归深度；当为null时或小于等于0时，不递归目录</param>
        /// <returns></returns>
        private static List<string> GetDirectories(IList<string> directoryPaths, uint deep)
        {
            var allOfDirectoryPaths = new List<string>();
            allOfDirectoryPaths.AddRange(directoryPaths);
            if (deep == 0)
            {
                return allOfDirectoryPaths;
            }
            foreach (var directoryPath in directoryPaths)
            {
                var childDirectoryPaths = GetDirectories(directoryPath, deep);
                allOfDirectoryPaths.AddRange(childDirectoryPaths);
            }
            return allOfDirectoryPaths;
        }
    }
}
