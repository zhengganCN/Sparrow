using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class FloatModel
    {
        [Required(ErrorMessage = "必填")]
        public float Price_1 { get; set; }
        [Required(ErrorMessage = "必填")]
        public float? Price_2 { get; set; }
    }
}
