using System.ComponentModel.DataAnnotations;

namespace Sparrow.StandardResult.WebTest.Models
{
    public class Wind
    {
        [Required]
        public double? Speed { get; set; }
        [Required]
        public string Level { get; set; }
        public Wind[] Winds { get; set; }
    }
}
