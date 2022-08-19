using System.ComponentModel.DataAnnotations;

namespace Sparrow.StandardResult.WebTest
{
    public class QueryWeather
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "日期")]
        [Required(ErrorMessage = "{0}为必填项")]
        public int? Day { get; set; }
    }
}
