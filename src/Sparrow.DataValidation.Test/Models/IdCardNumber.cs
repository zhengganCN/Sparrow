using Sparrow.DataValidation.Attributes;

namespace Sparrow.DataValidation.Test.Models
{
    internal class IdCardNumber
    {
        [SparrowCertificate]
        public string IdCard { get; set; }
    }
}
