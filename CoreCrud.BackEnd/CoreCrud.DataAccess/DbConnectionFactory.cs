using CoreCrud.DataAccess.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace CoreCrud.DataAccess
{
    class DbConnectionFactory
    {
        public static IDbConnection GetDbConnection(DbConnectionTypesEnum dbType, string connectionString)
        {
            IDbConnection connection = null;

            switch (dbType)
            {
                case DbConnectionTypesEnum.SQL:
                    connection = new SqlConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }

            connection.Open();
            return connection;
        }
    }
}