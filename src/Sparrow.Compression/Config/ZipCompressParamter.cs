using System.IO.Compression;

namespace Sparrow.Compression
{
    /// <summary>
    /// Zip压缩参数
    /// </summary>
    public class ZipCompressParamter
    {
        /// <summary>
        /// 压缩文件的输出路径，会自动在文件的末尾添加.zip扩展名；如（CompressedFilePath属性值为“C:\temp\demo”,则输出的压缩文件名称为“C:\temp\demo.zip”）
        /// </summary>
        public string CompressedFilePath { get; set; }
        /// <summary>
        /// 压缩等级，默认Optimal以最佳方式完成压缩操作，不过，需要耗费更长的时间
        /// </summary>
        public CompressionLevel CompressionLevel { get; set; }
        /// <summary>
        /// 是否在压缩文件中创建源目录
        /// </summary>
        public bool CreateDirectoryInCompressionFile { get; set; } = false;
    }
}
