using SqlSugar;

namespace Sparrow.Database.SqlSugar
{
    public class DbContextOptionsBuilder
    {
        internal ConnectionConfig Connection;
        public void SetConnectionConfig(ConnectionConfig connection)
        {
            Connection = connection;
        }
    }
}
