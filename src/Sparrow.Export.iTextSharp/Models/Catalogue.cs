using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp.Models
{
    public class Catalogue
    {
        internal Catalogue() { }
        public string Title { get; set; }
        public int LinkPageNumber { get; set; }
        public List<Catalogue> Children { get; private set; } = new List<Catalogue>();
    }
}
