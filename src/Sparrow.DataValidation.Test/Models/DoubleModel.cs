using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class DoubleModel
    {
        [Required(ErrorMessage = "必填")]
        public double Price_1 { get; set; }
        [Required(ErrorMessage = "必填")]
        public double? Price_2 { get; set; }
    }
}
