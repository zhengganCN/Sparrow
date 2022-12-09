using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class IntModel
    {
        [Required(ErrorMessage = "必填")]
        public int Age_1 { get; set; }
        [Required(ErrorMessage = "必填")]
        public int? Age_2 { get; set; }
    }
}
