using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Configuration.Test.models
{
    internal class Person
    {
        public int? Age { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public SimpleObject[] list_obj { get; set; }
    }
}
