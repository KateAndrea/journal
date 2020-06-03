using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursa4
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "skirrilex.saloid.pp.ua";
            int port = 3306;
            string database = "journal";
            string username = "john";
            string password = "creator";
            return DB_MySQL_Utils.GetMySQLConnection(host, port, database, username, password);
        }
    }
}
