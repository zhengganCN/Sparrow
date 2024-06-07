using Sparrow.Database.SqlSugar.Migrations;

namespace Sparrow.Database.SqlSugar
{
    internal static class DatabaseStaticValue
    {
        internal static MigrationOptions MigrationOptions
        {
            get
            {
                var options = new MigrationOptions
                {
                    Major = 0,
                    Minor = 0,
                    Revision = 0,
                    Temporary = 0,
                    Name = "database"
                };
                return options;
            }
        }
    }
}
