using Sparrow.DataValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class Student
    {
        //public Book[] Books_1 { get; set; } = new Book[] { new Book(), new Book() };
        //public IList<Book> Books_2 { get; set; } = new List<Book> { new Book(), new Book() };
        //public IEnumerable<Book> Books_3 { get; set; } = new List<Book> { new Book(), new Book() };
        public string[] Tags { get; set; } = new string[] { "flower", "flower" };
        public int Age { get; set; }
        [Display(Name = "颜色")]
        [Required(ErrorMessage = "{0}为必填项")]
        [MaxLength(6, ErrorMessage = "{0}为必填项")]
        [SparrowAllowValue("yellow", ErrorMessage = "{0}无效颜色")]
        public string Color { get; set; } = "l";
    }
}
