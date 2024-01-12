using Sparrow.Database.SqlSugar.Models;

namespace Sparrow.Database.SqlSugar
{
    internal static class DatabaseStaticValue
    {
        internal static SparrowVersion Version { get; set; } = new SparrowVersion(0, 0, 0, 1);
    }
}
