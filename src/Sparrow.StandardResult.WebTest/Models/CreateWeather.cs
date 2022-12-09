using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.StandardResult.WebTest.Models
{
    public class CreateWeather
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "日期")]
        [Required(ErrorMessage = "{0}为必填项")]
        public int? Day { get; set; }
        [Required]
        public List<Wind> Winds { get; set; }
    }
}
