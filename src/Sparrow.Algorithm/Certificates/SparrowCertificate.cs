using Sparrow.Algorithm.Enums;

namespace Sparrow.Algorithm.Certificates
{
    /// <summary>
    /// 证件
    /// </summary>
    public static class SparrowCertificate
    {
        /// <summary>
        /// 验证证件号是否正确
        /// </summary>
        /// <param name="type">证件类型</param>
        /// <param name="number">证件号码</param>
        /// <returns></returns>
        public static bool Verify(CertificateType type, string number)
        {
            switch (type)
            {
                case CertificateType.IdentityCard:
                    return SparrowIdentityCard.Verify(number);
            }
            return false;
        }
    }
}
