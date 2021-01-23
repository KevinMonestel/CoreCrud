using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CoreCrud.DataAccess
{
    class DbConnectionFactory
    {
        public static IDbConnection GetDbConnection(EDbConnectionTypes dbType, string connectionString)
        {
            IDbConnection connection = null;

            switch (dbType)
            {
                case EDbConnectionTypes.SQL:
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

    public enum EDbConnectionTypes
    {
        SQL
    }
}