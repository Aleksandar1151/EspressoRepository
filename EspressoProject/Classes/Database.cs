using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EspressoProject.Classes
{

    public class Database
    {
        public static MySqlConnection dbConn;
        public static void InitializeDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
            dbConn = new MySqlConnection(connectionString);

        }
    }
}
