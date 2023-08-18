namespace Sparrow.StandardResult.Test
{
#pragma warning disable IDE1006 // 命名样式
    internal class DefinedDto
    {
        public string defined_code { get; set; }
        public string defined_message { get; set; }
        public object defined_data { get; set; }
        public bool defined_success { get; set; }
        public object defined_time { get; set; }
        public string defined_traceid { get; set; }
    }
    internal class OtherDto
    {
        public string other_code { get; set; }
        public string other_message { get; set; }
        public object other_data { get; set; }
        public bool other_success { get; set; }
        public object other_time { get; set; }
        public string other_traceid { get; set; }
    }
    internal class DefinedPagination
    {
        public object list { get; set; }
        public int page_num { get; set; }
        public int page_size { get; set; }
        public int total { get; set; }
        public int page_count { get; set; }
    }
    internal class DefinedPaginationAdditional : DefinedPagination
    {
        public string name { get; set; }
        public int age { get; set; }
    }
#pragma warning restore IDE1006 // 命名样式
}
