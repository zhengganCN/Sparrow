using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Test.Models
{
    internal class ListModel
    {
        [Required]
        public IList<int> List_1 { get; set; }
        [Required]
        public IEnumerable<int> List_2 { get; set; } = new List<int> { 1, 2 };
        [Required]
        [MaxLength(3)]
        public List<int> List_3 { get; set; } = new List<int> { 1, 2, 3, 4 };
        [Required]
        public IList<ListChild_1> List_4 { get; set; } = new List<ListChild_1>
        {
            new ListChild_1
            {
                Name_1 = "张佩",
                Age = 11,
                Book = new ListChild_2
                {
                    Name_2 = "从零开始",
                    Price = 123
                }
            }
        };
        [Required]
        public IEnumerable<ListChild_1> List_5 { get; set; } = new List<ListChild_1>
        {
            new ListChild_1
            {
                Book = new ListChild_2()
            }
        };
        [Required]
        public List<ListChild_1> List_6 { get; set; } = new List<ListChild_1>
        {
            new ListChild_1
            {
                Name_1 = "刘茂",
                Age = 56,
                Book = new ListChild_2()
            }
        };
    }

    internal class ListChild_1
    {
        [Required]
        public string Name_1 { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public ListChild_2 Book { get; set; }
    }
    internal class ListChild_2
    {
        [Required]
        public string Name_2 { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
