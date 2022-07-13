using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 文件大小验证特性，只对类型IFormFile和IFormFileCollection有效
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FileSizeAttribute : ValidationAttribute
    {
        /// <summary>
        /// 文件大小验证特性
        /// </summary>
        public int Size { get; set; } = 1000;
        /// <summary>
        /// 大小单位，默认值为KB
        /// </summary>
        public SizeUnit Unit { get; set; } = SizeUnit.UnitKB;
        /// <summary>
        /// 重写验证逻辑
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return true;
            }
            bool result = false;
            if (value is IFormFile file)
            {
                result = ValidFileSize(file);
            }
            else if (value is IFormFileCollection files)
            {
                foreach (IFormFile fileItem in files)
                {
                    result = ValidFileSize(fileItem);
                    if (!result)
                    {
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 验证文件大小是否符合要求
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool ValidFileSize(IFormFile file)
        {
            var maxBytes = 0;
            switch (Unit)
            {
                case SizeUnit.UnitByte:
                    maxBytes = Size;
                    break;
                case SizeUnit.UnitKB:
                    maxBytes = Size * 1024;
                    break;
                case SizeUnit.UnitMB:
                    maxBytes = Size * 1024 * 1024;
                    break;
            }
            return file.Length <= maxBytes;
        }


    }
}
