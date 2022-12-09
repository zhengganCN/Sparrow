using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class ShortModel
    {
        [Required(ErrorMessage = "必填")]
        public short Short_1 { get; set; }
        [Required(ErrorMessage = "必填")]
        public short? Short_2 { get; set; }
    }
}
