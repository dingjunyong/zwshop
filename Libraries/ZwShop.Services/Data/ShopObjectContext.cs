using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ZwShop.Services.Data
{
    public class ShopObjectContext
    {
        private readonly string _connectionString;
        public ShopObjectContext(string connectionString) 
        {
            _connectionString = connectionString;
        }


        public IDbConnection OpenConnection() 
        {
            var connection = GetSqlConnection();
            connection.Open();
            return connection;
        }

        private SqlConnection GetSqlConnection() 
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }
    }
}
