using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursa4
{
    class DB_MySQL_Utils
    {
        public static MySqlConnection GetMySQLConnection(string host, int port, string database, string username, string password)
        {
            string connectionString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
