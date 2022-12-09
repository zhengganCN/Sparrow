using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class EnumModel
    {
        public enum Sex
        {
            Man = 1,
            Women = 2
        }

        [Required]
        public Sex? Sex_1 { get; set; }
    }
}
