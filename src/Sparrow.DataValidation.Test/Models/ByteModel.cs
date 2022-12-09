using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    public class ByteModel
    {
        [Required(ErrorMessage = "必填")]
        public byte Byte_1 { get; set; }
        [Required(ErrorMessage = "必填")]
        public byte? Byte_2 { get; set; }

    }
}
