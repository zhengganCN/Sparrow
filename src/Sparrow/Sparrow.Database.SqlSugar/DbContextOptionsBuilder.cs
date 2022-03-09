using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

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
