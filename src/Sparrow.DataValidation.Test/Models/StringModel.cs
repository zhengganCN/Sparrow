using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class StringModel
    {
        [MaxLength(5, ErrorMessage = "过长")]
        public string String_1 { get; set; } = "123456";
    }
}
