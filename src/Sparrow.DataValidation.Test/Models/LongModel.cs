using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class LongModel
    {
        [Required(ErrorMessage = "必填")]
        public long Pages_1 { get; set; }
        [Required(ErrorMessage = "必填")]
        public long? Pages_2 { get; set; }
    }
}
