namespace Sparrow.StandardResult.Test.Models
{
    internal class DefinedPagination
    {
        public object list { get; set; }
        public int page_num { get; set; }
        public int page_size { get; set; }
        public int total { get; set; }
        public int page_count { get; set; }
    }
}
