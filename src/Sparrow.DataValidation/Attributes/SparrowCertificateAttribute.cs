using Sparrow.Algorithm.Certificates;
using Sparrow.Algorithm.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 允许的值验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SparrowCertificateAttribute : ValidationAttribute
    {
        /// <summary>
        /// 证件类型，默认值位身份证
        /// </summary>
        public CertificateType Type { get; set; } = CertificateType.IdentityCard;
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
            return SparrowCertificate.Verify(Type, value as string);
        }
    }
}
