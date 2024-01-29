using Sparrow.Database.SqlSugar.Models;

namespace Sparrow.Database.SqlSugar
{
    internal static class DatabaseStaticValue
    {
        internal static Migration MigrationOptions
        {
            get
            {
                return new Migration
                {
                    major = 0,
                    minor = 0,
                    revision = 0,
                    temporary = 0,
                    name = "database"
                };
            }
        }
    }
}
